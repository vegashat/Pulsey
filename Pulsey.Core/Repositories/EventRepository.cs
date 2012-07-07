using System.Collections.Generic;
using System.Data;
using System.Linq;

using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class EventRepository : BaseRepository
    {
        public ICollection<Event> Get()
        {
            using (var context = GetContext())
            {
                return context.Events.ToList();
            }
        }

        public Event Save(Event model)
        {
            using (var context = GetContext())
            {
                if (model.Id == 0)
                {
                    context.Entry<Event>(model).State = EntityState.Added;
                }
                else
                {
                    context.Entry<Event>(model).State = EntityState.Modified;
                }

                context.SaveChanges();

                return model;
            }
        }
    }
}
