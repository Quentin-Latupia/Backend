USE [padel2025]

/****** Object:  User [adminGlobal]    Script Date: 11/06/2026 19:04:03 ******/
CREATE USER [adminGlobal] FOR LOGIN [adminGlobal] WITH DEFAULT_SCHEMA=[dbo]

/****** Object:  User [adminSite]    Script Date: 11/06/2026 19:04:03 ******/
CREATE USER [adminSite] FOR LOGIN [adminSite] WITH DEFAULT_SCHEMA=[dbo]

/****** Object:  User [membrePadel]    Script Date: 11/06/2026 19:04:03 ******/
CREATE USER [membrePadel] FOR LOGIN [membrePadel] WITH DEFAULT_SCHEMA=[dbo]

ALTER ROLE [membre] ADD MEMBER [membrePadel]

