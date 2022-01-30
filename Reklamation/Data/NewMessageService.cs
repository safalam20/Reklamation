using System;
using Reklamation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient.Base.EventArgs;
using Microsoft.EntityFrameworkCore;

namespace Reklamation.Data
{
    public class NewMessageService : INewMessageService, IDisposable
    {
        private const string TableName = "KTrkl_Message";
        private SqlTableDependency<KTrkl_Message> _notifier;
        private IConfiguration _configuration;

        public event NewMessageDelegate OnNewMessageChanged;

        public NewMessageService(IConfiguration configuration)
        {
            _configuration = configuration;

            _notifier = new SqlTableDependency<KTrkl_Message>(_configuration["ConnectionStrings:DefaultConnection"], TableName);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();

        }

        private void TableDependency_Changed(object sender, RecordChangedEventArgs<KTrkl_Message> e)
        {
            
            if (this.OnNewMessageChanged != null && e.ChangeType.Equals(TableDependency.SqlClient.Base.Enums.ChangeType.Insert))
            {
                this.OnNewMessageChanged(this, new NewMessageChangeEventArgs(e.Entity, e.EntityOldValues));
            }
        }
       


        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}
