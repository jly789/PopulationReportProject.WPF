using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopAppMaster.Interfaces;
using UiDesktopAppMaster.Models;

namespace UiDesktopAppMaster.Services
{
    internal class DateTimeService : IDateTime
    {
        public Func<QueryContext, TResult> CompileQuery<TResult>(System.Linq.Expressions.Expression query, bool async)
        {
            throw new NotImplementedException();
        }

        public DateTime? GetCurrentTime()
        {
            return DateTime.Now;
        }

        public int SaveChanges(IList<IUpdateEntry> entries)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
