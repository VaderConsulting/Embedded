using System;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.FEZ;

namespace Toolbox.NETMF.Hardware
{
    /// <summary>
    /// Rotary Encoder
    /// </summary>
    public class RotaryEncoder : IDisposable
    {

        /// <summary>
        /// This event will be triggered on rotation
        /// </summary>
        public event NativeEventHandler Rotated;
        public event NativeEventHandler Pressed;

        /// <summary>Reference to the interrupt port on the A-pin</summary>
        private InterruptPort _PinA;
        /// <summary>Reference to the interrupt port on the B-pin</summary>
        private InterruptPort _PinB;
        /// <summary>Reference to the interrupt port on the C-pin</summary>
        private InterruptPort _PinC;

        /// <summary>Stores the odd value of pin A</summary>
        private bool _OddA = false;
        /// <summary>Stores the odd value of pin B</summary>
        private bool _OddB = false;
        /// <summary>Swaps at each measurement, we act when we get two measurements</summary>
        private bool _Even = true;
        /// <summary>Stores the current value of pin C</summary>
        private uint _C = 1;

        /// <summary>
        /// Initiates a rotary encoder
        /// </summary>
        /// <param name="PinA">Pin A</param>
        /// <param name="PinB">Pin B</param>
        public RotaryEncoder(FEZ_Pin.Interrupt PinA, FEZ_Pin.Interrupt PinB, FEZ_Pin.Interrupt PinC)
        {
            this._PinA = new InterruptPort((Cpu.Pin)PinA, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            this._PinB = new InterruptPort((Cpu.Pin)PinB, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            this._PinC = new InterruptPort((Cpu.Pin)PinC, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            this._PinA.OnInterrupt += new NativeEventHandler(_Pin_OnInterrupt);
            this._PinB.OnInterrupt += new NativeEventHandler(_Pin_OnInterrupt);
            this._PinC.OnInterrupt += new NativeEventHandler(_Button_OnInterrupt);
        }

        /// <summary>
        /// One of the pins has triggered an interrupt
        /// </summary>
        /// <param name="PinId">The Id of the pin</param>
        /// <param name="Value">It's new value</param>
        /// <param name="Time">Timestamp of the event</param>
        private void _Pin_OnInterrupt(uint PinId, uint Value, DateTime Time)
        {
            // Takes the last value
            bool CurrA = this._PinA.Read();
            bool CurrB = this._PinB.Read();

            // This is an odd measurement, we store the data so we can compare it with the measurement next time
            this._Even = !this._Even;
            if (!this._Even)
            {
                this._OddA = CurrA;
                this._OddB = CurrB;
                return;
            }

            // Was there an actual change?
            if (CurrA == this._OddA && CurrB == this._OddB)
                return;

            // Is there an event bound?
            if (this.Rotated == null)
                return;

            // If pin A is high and pin B just went low, we're moving counter clockwise
            // If Pin A is high and pin B didn't went low, we're moving clockwise
            // If pin A was low and pin B just went high, we're moving counter clockwise
            // If pin A was low and pin B didn't went high, we're moving clockwise
            if (this._OddA && !CurrB)
                this.Rotated(0, 0, Time);
            else if (this._OddA)
                this.Rotated(0, 1, Time);
            else if (CurrB)
                this.Rotated(0, 0, Time);
            else
                this.Rotated(0, 1, Time);
        }

        private void _Button_OnInterrupt(uint PinId, uint Value, DateTime Time)
        {
            if (Value != _C)
            {
                _C = Value;
                this.Pressed(PinId, Value, Time);
            }

        }

        /// <summary>
        /// Frees all pins and disposes this object
        /// </summary>
        public void Dispose()
        {
            this._PinA.Dispose();
            this._PinB.Dispose();
        }
    }
}
