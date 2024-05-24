using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    public class MemberList<T>
    {
        public  List<T> mem { get; set; }

        public MemberList()
        {

            mem = new List<T>();
        }

        public void AddMember(T member)
        {
            mem.Add(member);
        }

        public void RemoveMember(int index)
        {
            mem.RemoveAt(index);
            
        }

        
      
        public List<T> getMemberDetails()
        {
            return mem;
        }

    }
}
