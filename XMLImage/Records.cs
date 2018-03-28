using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLImage
{
    class Records: IEnumerator,IEnumerable
    {
        int aPosition = -1;
        private List<Record> RecordList { get; set; }

        public Records()
        {
            RecordList = new List<Record>();
        }

        public int Count
        {
            get { return RecordList.Count; }
        }

        public object Current
        {
            get
            {
                //throw new NotImplementedException();
                 return RecordList[aPosition]; 

            }
        }

        public void Add(Record R)
        {
            RecordList.Add(R);
        }

        public void Delete(Record R)
        {
            RecordList.Remove(R);
        }

        public bool MoveNext()
        {
            //throw new NotImplementedException();
            aPosition++;
            return (aPosition < RecordList.Count);
        }

        public void Reset()
        {
            //throw new NotImplementedException();
            aPosition = 0;
        }

        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException();
            return (IEnumerator)this;
        }
    }
}
