using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    delegate void DoeIets(object sender, TemperatureEventArgs args);

    class TemperatureEventArgs : EventArgs
    {
        public int Temperature { get; set; }
    }

    class Reactor
    {
        public event DoeIets OnTemperatureChange;

        public int Temperature { get; set; }
        public void SplitAtoms()
        {
            Temperature += 7;
            if (OnTemperatureChange != null)
            {
                OnTemperatureChange(this, new TemperatureEventArgs { Temperature = Temperature });
            }
        }
    }

    class Pump
    {
        private int _startCoolingAt;
        public Pump(int startCoolingAt)
        {
            _startCoolingAt = startCoolingAt;
        }
        public void StartCooling(object sender, TemperatureEventArgs args)
        {
            if (args.Temperature > _startCoolingAt)
            {
                Console.WriteLine("Cooling down: {0}", args.Temperature);
                ((Reactor)sender).Temperature -= 5;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var reactor = new Reactor();
            var pump1 = new Pump(25);
            var pump2 = new Pump(10);

            reactor.OnTemperatureChange += pump1.StartCooling;
            reactor.OnTemperatureChange += pump2.StartCooling;

            //reactor.AlsHetTeWarmWordt = null;

            for (int i = 0; i < 30; i++)
            {
                reactor.SplitAtoms();
            }
        }
    }
}
