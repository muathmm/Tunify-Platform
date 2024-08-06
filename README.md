# Tunify Platform

## Introduction

Tunify is a music platform designed to provide users with an exceptional listening experience through a diverse collection of songs, albums, and artists. The application features various functionalities such as creating playlists, managing subscriptions, and keeping up with the latest albums and songs.

## Entity-Relationship Diagram (ERD)

Below is the Entity-Relationship Diagram (ERD) that illustrates the overall data structure and relationships between different entities in the database:

![ERD Diagram](path/to/your/ERD-diagram.png)

## Overview of Entity Relationships

1. **User**
   - **Properties**: `UserId`, `Username`, `Join_Date`, `SubScriprion_ID`
   - **Relationships**:
     - A user is associated with one subscription through `SubScriprion_ID`.
     - A user can have many playlists.

2. **Subscription**
   - **Properties**: `SubscriptionId`, `SubscriptionType`, `Price`
   - **Relationships**:
     - A subscription can have many users associated with it.

3. **PlayList**
   - **Properties**: `PlayListId`, `UserId`, `PlayListName`, `CreatedDate`
   - **Relationships**:
     - A playlist is associated with one user.
     - A playlist can contain many songs through the `PlaylistSong` table.

4. **Song**
   - **Properties**: `SongId`, `Title`, `ArtistId`, `AlbumId`, `Duration`, `Genre`
   - **Relationships**:
     - Each song is associated with a specific artist.
     - Each song belongs to a specific album.
     - A song can appear in many playlists through the `PlaylistSong` table.

5. **Album**
   - **Properties**: `AlbumId`, `AlbumName`, `ReleaseDate`, `ArtistId`
   - **Relationships**:
     - An album is associated with one artist.
     - An album can contain many songs.

6. **Artist**
   - **Properties**: `ArtistId`, `Name`, `Bio`
   - **Relationships**:
     - An artist can have many albums and songs.

7. **PlaylistSong**
   - **Properties**: `SongId`, `PlaylistId`
   - **Relationships**:
     - This table represents the many-to-many relationship between songs and playlists.
     - A playlist can contain many songs, and a song can appear in many playlists.

## Running the Application

1. **Install Dependencies**:
   ```bash
   dotnet restore
