/*
Copyright 2010 GHI Electronics LLC
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace GHIElectronics.NETMF.FEZ
{
    public static partial class FEZ_Components
    {
        public class LED : IDisposable
        {
            OutputPort led;
            Timer timer;
            int onTime, offTime;
            bool disposed = false;
            bool timerRunning = false;
            bool blinkState;

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void Dispose()
            {
                if (!disposed)
                {
                    disposed = true;
                    timerRunning = false;
                    timer.Dispose();
                    led.Dispose();
                }
            }

            public LED(FEZ_Pin.Digital pin)
            {
                led = new OutputPort((Cpu.Pin)pin, true);
                timer = new Timer(Callback, null, Timeout.Infinite, Timeout.Infinite);
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void SetState(bool LED_state)
            {
                if (disposed)
                    throw new ObjectDisposedException();

                if (timerRunning)
                {
                    timer.Dispose();
                    timerRunning = false;
                }

                led.Write(LED_state);
            }

            public void TurnOn()
            {
                SetState(true);
            }

            public void ShutOff()
            {
                SetState(false);
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void StartBlinking(int onTime_mSec, int offTime_mSec)
            {
                if (disposed)
                    throw new ObjectDisposedException();

                this.onTime = onTime_mSec;
                this.offTime = offTime_mSec;

                timerRunning = true;
                blinkState = true;
                timer.Change(0, Timeout.Infinite);
            }

            public void StopBlinking()
            {
                StartBlinking(Timeout.Infinite, 0);
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            private void Callback(object o)
            {
                if (!timerRunning)
                    return;

                if (blinkState)
                {
                    led.Write(true);
                    timer.Change(onTime, Timeout.Infinite);
                }
                else
                {
                    led.Write(false);
                    timer.Change(offTime, Timeout.Infinite);
                }

                blinkState = !blinkState;
            }
        }
    }
}