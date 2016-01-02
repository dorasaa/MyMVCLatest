using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCLatest.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenereId { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual Genere Genere { get; set; }
        public virtual Artist Artist { get; set; }    
    }

    public class Genere {
        public virtual int GenereId { get; set; }
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }

    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
    }
}