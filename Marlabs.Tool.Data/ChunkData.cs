//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marlabs.Tool.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChunkData
    {
        public System.Guid ChunkID { get; set; }
        public System.Guid SnapshotDataID { get; set; }
        public Nullable<byte> ChunkFlags { get; set; }
        public string ChunkName { get; set; }
        public Nullable<int> ChunkType { get; set; }
        public Nullable<short> Version { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }
    }
}
