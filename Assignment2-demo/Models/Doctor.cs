
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace Assignment2.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Doctor
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Doctor()
    {

        this.Bookings = new HashSet<Booking>();

        this.Introductions = new HashSet<Introduction>();

    }


    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Booking> Bookings { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Introduction> Introductions { get; set; }

}

}
