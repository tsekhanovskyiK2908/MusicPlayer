USE[MusicPlayerDB]

INSERT INTO [dbo].[Format]([Name]) VALUES('flac');
INSERT INTO [dbo].[Format]([Name]) VALUES('mp3');
INSERT INTO [dbo].[Format]([Name]) VALUES('ogg');
INSERT INTO [dbo].[Format]([Name]) VALUES('wav');

INSERT INTO [dbo].[Genre]([Name]) VALUES('Rock');
INSERT INTO [dbo].[Genre]([Name]) VALUES('Melodic metalcore');
INSERT INTO [dbo].[Genre]([Name]) VALUES('Heavy metal');
INSERT INTO [dbo].[Genre]([Name]) VALUES('Alterantive rock');

INSERT INTO [dbo].[Artist]([Name], [Description]) VALUES('Three Days Grace', 'Three Days Grace is a Canadian rock band formed in Norwood, Ontario in 1997. 
Based in Toronto, the band''s original line-up consisted of guitarist and lead vocalist Adam Gontier, drummer and backing vocalist Neil Sanderson, and bassist Brad Walst.');
INSERT INTO [dbo].[Artist]([Name], [Description]) VALUES('Bullet for My Valentine', 'Bullet for My Valentine, 
often abbreviated as BFMV, are a Welsh heavy metal band from Bridgend, Wales, formed in 1998.');
