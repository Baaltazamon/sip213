//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sip213.DateBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class OFFICER
    {
        public int OFFICER_ID { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public System.DateTime START_DATE { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> CUST_ID { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
