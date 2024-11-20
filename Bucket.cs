using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7
{
    public class Bucket<T, S>
    {
        public T Id { get; set; }
        public S Data { get; set; }



        public Bucket()
        {

        }
        public Bucket(T id, S data)
        {
            Id = id;
            Data = data;
        }

        public override string ToString()
        {
            return $"Bucket Id: {Id} | Data: {Data}";
        }

    }
}
