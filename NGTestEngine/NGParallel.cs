using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NG
{
    public class NGParallel : NGEngine
    {
        private int _NumberOfUUTs = 1;

        public int NumberOfUUTs
        {
            get
            {
                return _NumberOfUUTs;
            }
            set
            {
                if (value > 0)
                {
                    _NumberOfUUTs = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected void PreUUT()
        {

        }

        protected void PostUUT()
        {

        }

        public void startThread(int id) {
            NGSequencial engine = new NGSequencial();
            engine.MainSequence = this.MainSequence;
            engine.Id = id; 
            engine.Start(); 
        }
        
        public void Start()
        {
            for (int i = 0; i < this.NumberOfUUTs; i++)
            {
                //Create new sequencial engine in seperate thread
                Thread t3 = new Thread(() => startThread(i));
                t3.Start();
            }
        }
    }
}


