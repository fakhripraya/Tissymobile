using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsrivaMobileWebAPI.Models
{
    public class DbUserBindingViewModel
    {
        public partial class dbuser
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public dbuser()
            {
                this.dbfriendlists = new HashSet<dbfriendlist>();
            }

            public string UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string CreateBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public string UpdateBy { get; set; }
            public Nullable<System.DateTime> UpdateDate { get; set; }
            public Nullable<bool> IsDelete { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<dbfriendlist> dbfriendlists { get; set; }
        }
    }
}