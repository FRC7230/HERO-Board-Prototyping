using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Hero_Simple_Application5
{
    
    public class Program
    {
                  static CTRE.Phoenix.Controller.GameController _gamepad = new CTRE.Phoenix.Controller.GameController(CTRE.Phoenix.UsbHostDevice.GetInstance(0));

        public static void Main()
        {
           

            OutputPort solonoid_extend = new OutputPort(CTRE.HERO.IO.Port5.Pin4, false);
            OutputPort solonoid_retract = new OutputPort(CTRE.HERO.IO.Port5.Pin6, false);
            OutputPort compressor = new OutputPort(CTRE.HERO.IO.Port5.Pin8, false);

            bool xButton = true;
            bool aButton = true;
            bool bButton = true;
            while(true)
                {
                xButton = _gamepad.GetButton(1);
                aButton = _gamepad.GetButton(2);
                bButton = _gamepad.GetButton(3);

                compressor.Write(xButton);
                solonoid_extend.Write(aButton);
                solonoid_retract.Write(bButton);



                Thread.Sleep(10); 
                }
            }
        }
    }

