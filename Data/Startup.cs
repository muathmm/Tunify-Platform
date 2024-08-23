using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
    {


        public TunifyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithOne(s => s.User)
                .HasForeignKey<Subscription>(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlayLists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(art => art.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(art => art.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(alb => alb.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.SongId, ps.PlaylistId });

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.PlayList)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
        new User { UserId = 1, Username = "John Doe", Join_Date = new DateTime(2024, 1, 1), SubScriprion_ID = 1 },
        new User { UserId = 2, Username = "Jane Smith", Join_Date = new DateTime(2024, 2, 1), SubScriprion_ID = 2 }
    );
  

 
            modelBuilder.Entity<Subscription>().HasData(
          new Subscription { SubscriptionId = 1, SubscriptionType = "Basic", Price = 9.99m },
          new Subscription { SubscriptionId = 2, SubscriptionType = "Premium", Price = 19.99m }
      );


            modelBuilder.Entity<Artist>().HasData(
        new Artist { ArtistId = 1, Name = "Artist 1", Bio = "Bio of Artist 1" },
        new Artist { ArtistId = 2, Name = "Artist 2", Bio = "Bio of Artist 2" }
    );

          
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, AlbumName = "Album 1", ReleaseDate = new DateTime(2023, 1, 1), ArtistId = 1 },
                new Album { AlbumId = 2, AlbumName = "Album 2", ReleaseDate = new DateTime(2023, 2, 1), ArtistId = 2 }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = "3:30", Genre = "Pop" },
                new Song { SongId = 2, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration = "4:00", Genre = "Rock" }
            );

          
            modelBuilder.Entity<PlayList>().HasData(
                new PlayList { PlayListId = 1, UserId = 1, PlayListName = "My Favorites", CreatedDate = DateTime.Now },
                  new PlayList { PlayListId = 2, UserId = 2, PlayListName = "My Favorites", CreatedDate = DateTime.Now },
                  new PlayList { PlayListId = 3, UserId = 1, PlayListName = "My Favorites", CreatedDate = DateTime.Now }
            );

         
            modelBuilder.Entity<PlaylistSong>().HasData(
                new PlaylistSong { PlaylistId = 1, SongId = 1 },
                new PlaylistSong { PlaylistId = 1, SongId = 2 }
            );
        }
    }


    }
