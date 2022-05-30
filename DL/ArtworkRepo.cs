using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ArtworkRepo : IArtworkRepo
    {
        private VanquishDBContext db;
        public ArtworkRepo(VanquishDBContext db)
        {
            this.db = db;
        }
        public Artwork AddArt(Artwork art)
        {
            db.artworks.Add(art);
            db.SaveChanges();
            return art;
        }

        public void DeleteArt(int id)
        {
            var deletethis = db.artworks.Where(u => u.Id == id).FirstOrDefault();
            if (deletethis != null)
                db.artworks.Remove(deletethis);
        }

        public List<Artwork> GetAllArtworks()
        {
            return db.artworks.ToList();
        }

        public List<Artwork> GetArtByUserID(int UserId)
        {
            return db.artworks.Where(a => a.UserId == UserId).ToList();
        }
    }
}
