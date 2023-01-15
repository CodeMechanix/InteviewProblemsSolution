using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nuvei
{
    public class PersonCollection
    {
        private IComparer<IPerson> _comparer;
        private List<IPerson> _people; //Bonus: LinkedList<IPerson>,  May be used instead of List<IPerson>

        private object _lock;

        //publishes a notification to subscriber objects upon any Add/Remove.
        public event Action<IPerson> OnAdd;
        public event Action<IPerson> OnDelete;
        public event Action<int> CountUpdate;

        public PersonCollection(IComparer<IPerson> comparer)
        {
            _lock = new object();
            _comparer = comparer;
            _people = new List<IPerson>();

            StartCountPublish();
        }

        //Add - adds the person object which is given as input. This operation may be performed in WC
        //time complexity of O(n)
        public void Add(IPerson person)
        {
            lock (_lock)
            {
                if (_people.Count == 0)
                {
                    _people.Add(person);
                }
                else
                {
                    int insertAt = _people.Count;

                    for (var index = 0; index < _people.Count; index++)
                    {
                        var personFromList = _people[index];
                        var compare = _comparer.Compare(person, personFromList);
                        if (compare < 0)
                        {
                            insertAt = index;
                            break;
                        }
                    }

                    _people.Insert(insertAt, person);
                }

                OnAdd?.BeginInvoke(person, null, null);
            }
        }

        //Remove - removes the person object with the maximum (explanation below) value and returns
        //it.This operation must be performed in WC time complexity of O(1)
        public IPerson Remove()
        {
            lock (_lock)
            {
                var lastOrDefault = _people.LastOrDefault();
                _people.RemoveAt(_people.Count - 1);

                OnDelete?.BeginInvoke(lastOrDefault, null, null);
                return lastOrDefault;
            }
        }

        //Bonus:Every 60 seconds the collection will notify to all subscribers about how much persons it is holding.
        private void StartCountPublish()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    lock (_lock)
                    {
                        CountUpdate?.BeginInvoke(_people.Count, null, null);
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(60));
                }
            });
        }
    }
}