CREATE TABLE [dbo].[Capability] (
    [Id]         INT            NOT NULL,
    [Name]       NVARCHAR (250) NOT NULL,
    [Value_Type] NVARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Device] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT            NOT NULL,
    [Name]     NVARCHAR (250) NOT NULL,
    [Email]    NVARCHAR (250) NOT NULL,
    [Password] NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[DeviceCapability] (
    [Id_Device]     INT NOT NULL,
    [Id_Capability] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Device] ASC, [Id_Capability] ASC),
    CONSTRAINT [FK_DeviceCapability_Capability] FOREIGN KEY ([Id_Capability]) REFERENCES [dbo].[Capability] ([Id]),
    CONSTRAINT [FK_DeviceCapability_Device] FOREIGN KEY ([Id_Device]) REFERENCES [dbo].[Device] ([Id])
);


CREATE TABLE [dbo].[UserDevice] (
    [Id_User]   INT            NOT NULL,
    [Id_Device] INT            NOT NULL,
    [Status]    NVARCHAR (250) NULL,
    CONSTRAINT [PK_UserDevice] PRIMARY KEY CLUSTERED ([Id_User] ASC, [Id_Device] ASC),
    CONSTRAINT [FK_UserDevice_User] FOREIGN KEY ([Id_User]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserDevice_Device] FOREIGN KEY ([Id_Device]) REFERENCES [dbo].[Device] ([Id])
);

