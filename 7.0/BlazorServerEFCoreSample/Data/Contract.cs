namespace BlazorServerEFCoreSample.Data
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contact entity.
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// First name.
        /// </summary>
        public Guid GLobalFolioId { get; set; }
        public int LocalFolioId { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public Guid GlobalEnvelopeId { get; set; }
        public int LocalEnvelopeId { get; set; }


        /// <summary>
        /// First name.
        /// </summary>
        public Guid GlobalOwnerId { get; set; }
        public int LocalOwnerId { get; set; }


        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }

    }
   
}
