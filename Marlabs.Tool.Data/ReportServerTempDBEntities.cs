using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
namespace Marlabs.Tool.Data
{

    /// <summary>
    ///  No use of this entity for now .
    /// </summary>
   public partial class ReportServerTempDBEntities
    {
        private readonly bool _isReadOnly;
        public override int SaveChanges()
        {
            if (_isReadOnly)
                throw new InvalidOperationException("SaveChanges cannot be called when ReadOnly");
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            return 0;
        }
    }
}
