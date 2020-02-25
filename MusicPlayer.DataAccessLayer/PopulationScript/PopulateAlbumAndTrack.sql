USE[MusicPlayerDB]

DECLARE @rockGenreId uniqueidentifier,
		@flacFormatId uniqueidentifier,
		@tdgId uniqueidentifier;

SET @rockGenreId = (SELECT Id FROM [dbo].[Genre] WHERE [Name]='Rock');
SET @flacFormatId = (SELECT Id FROM [dbo].[Format] WHERE [Name]='flac');
SET @tdgId = (SELECT Id FROM [dbo].[Artist] WHERE [Name]='Three Days Grace');

INSERT INTO [dbo].[Album]([Name], ArtistId, ReleaseDate, RecordLabel) VALUES('Three Days Grace'
, @tdgId,'20030722 12:00:00 PM' ,'Vespa Studios');
INSERT INTO [dbo].[Album]([Name], ArtistId, ReleaseDate, RecordLabel) VALUES('One-X'
, @tdgId, '20060613 12:00:00 PM' ,'Jive');
INSERT INTO [dbo].[Album]([Name], ArtistId, ReleaseDate, RecordLabel) VALUES('Life Starts Now'
, @tdgId, '20090922 12:00:00 PM','Jive/Zomba');

DECLARE @tdgAlbumId uniqueidentifier,
		@onexAlbumId uniqueidentifier,
		@lifeStartsNowId uniqueidentifier;

SET @tdgAlbumId = (SELECT Id FROM [dbo].[Album] WHERE [Name]='Three Days Grace');
SET @onexAlbumId = (SELECT Id FROM [dbo].[Album] WHERE [Name]='One-X');
SET @lifeStartsNowId = (SELECT Id FROM [dbo].[Album] WHERE [Name]='Life Starts Now');

INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('I Hate Everything About You','00:03:51','E:\Development\MusicForPlayer\03 - I Hate Everything About You.flac'
,@tdgAlbumId, @rockGenreId, @flacFormatId);
INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('Drown','00:03:28','E:\Development\MusicForPlayer\09 - Drown.flac'
,@tdgAlbumId, @rockGenreId, @flacFormatId);
INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('Wake Up','00:03:26','E:\Development\MusicForPlayer\10 - Wake Up.flac'
,@tdgAlbumId, @rockGenreId, @flacFormatId);
INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('Over And Over','00:03:11','E:\Development\MusicForPlayer\09 - Over and Over.flac'
,@onexAlbumId, @rockGenreId, @flacFormatId);
INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('Gone Forever','00:03:41','E:\Development\MusicForPlayer\11 - Gone Forever.flac'
,@onexAlbumId, @rockGenreId, @flacFormatId);
INSERT INTO [dbo].[Track]([Name], Duration, PathToFile, AlbumId, GenreId, FormatId)
VALUES('Last To Know','00:03:27','E:\Development\MusicForPlayer\07 Last To Know.flac'
,@lifeStartsNowId, @rockGenreId, @flacFormatId);
