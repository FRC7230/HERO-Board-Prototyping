using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Hero_Simple_Application5 //does this work?
{
    
    public class Program
    {
                    static CTRE.Phoenix.Controller.GameController _gamepad = new CTRE.Phoenix.Controller.GameController(CTRE.Phoenix.UsbHostDevice.GetInstance(0));
                    static CTRE.Phoenix.MotorControl.CAN.TalonSRX Talon1 = new CTRE.Phoenix.MotorControl.CAN.TalonSRX(3);
        static CTRE.Phoenix.MotorControl.CAN.TalonSRX Talon2 = new CTRE.Phoenix.MotorControl.CAN.TalonSRX(4);
        public static void Main()
        {

         
            

            uint period = 50000; //period between pulses
            uint duration = 1500; //duration of pulse
            PWM pwm_9 = new PWM(CTRE.HERO.IO.Port3.PWM_Pin9, period, duration,
            PWM.ScaleFactor.Microseconds, false);

            pwm_9.Start();
        

            OutputPort solonoid_extend = new OutputPort(CTRE.HERO.IO.Port5.Pin4, false);
            OutputPort solonoid_retract = new OutputPort(CTRE.HERO.IO.Port5.Pin6, false);
            OutputPort compressor = new OutputPort(CTRE.HERO.IO.Port5.Pin8, false);

            bool xButton = true; //compressor
            bool aButton = true; 
            bool bButton = true;
            while(true) //feeds us info
                {
                Talon1.Set(CTRE.Phoenix.MotorControl.ControlMode.PercentOutput, _gamepad.GetAxis(1) + _gamepad.GetAxis(2));
                Talon2.Set(CTRE.Phoenix.MotorControl.ControlMode.PercentOutput, _gamepad.GetAxis(1) - _gamepad.GetAxis(2));

                pwm_9.Duration = (uint)_gamepad.GetAxis(1) * 50000;

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

