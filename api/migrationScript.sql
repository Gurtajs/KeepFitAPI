IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [MuscleGroups] (
    [MuscleGroupId] int NOT NULL IDENTITY,
    [MuscleGroup] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_MuscleGroups] PRIMARY KEY ([MuscleGroupId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [ProfilePicture] nvarchar(max) NULL,
    [Weight] int NULL,
    [Height] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Workouts] (
    [WorkoutId] int NOT NULL IDENTITY,
    [ExerciseName] nvarchar(max) NOT NULL,
    [Weight] int NOT NULL,
    [Sets] int NOT NULL,
    [Reps] int NOT NULL,
    [WorkoutDate] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    [UsersUserId] int NULL,
    [MuscleGroupId] int NOT NULL,
    [MuscleGroupsMuscleGroupId] int NULL,
    CONSTRAINT [PK_Workouts] PRIMARY KEY ([WorkoutId]),
    CONSTRAINT [FK_Workouts_MuscleGroups_MuscleGroupsMuscleGroupId] FOREIGN KEY ([MuscleGroupsMuscleGroupId]) REFERENCES [MuscleGroups] ([MuscleGroupId]),
    CONSTRAINT [FK_Workouts_Users_UsersUserId] FOREIGN KEY ([UsersUserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE INDEX [IX_Workouts_MuscleGroupsMuscleGroupId] ON [Workouts] ([MuscleGroupsMuscleGroupId]);
GO

CREATE INDEX [IX_Workouts_UsersUserId] ON [Workouts] ([UsersUserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240808092535_init', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240808093137_updated', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Workouts]') AND [c].[name] = N'MuscleGroupId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Workouts] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Workouts] DROP COLUMN [MuscleGroupId];
GO

ALTER TABLE [Workouts] ADD [MuscleGroup] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240808094720_updatedvers', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240808095110_updatedvers1', N'8.0.7');
GO

COMMIT;
GO

