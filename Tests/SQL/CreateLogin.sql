--USE [master]


/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [membrePadel]    Script Date: 11/06/2026 21:30:36 ******/
--CREATE LOGIN [membrePadel] WITH PASSWORD=N'lGu3zgIJ43fi1DG5h7AnTgxRzudJ/XixmmrmDC5JcU4=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Français], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'membrePadel')
BEGIN
  CREATE LOGIN [membrePadel] WITH PASSWORD = N'lGu3zgIJ43fi1DG5h7AnTgxRzudJ/XixmmrmDC5JcU4=', CHECK_POLICY = OFF;
  ALTER LOGIN [membrePadel] DISABLE;
END

ALTER LOGIN [membrePadel] DISABLE


/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [adminGlobal]    Script Date: 11/06/2026 21:31:55 ******/
--CREATE LOGIN [adminGlobal] WITH PASSWORD=N'gBkxlxF3pNhbD7Xxu5IIHoUCaXyuylh+XGn0DP4Uckc=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Français], CHECK_EXPIRATION=ON, CHECK_POLICY=ON

IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'adminGlobal')
BEGIN
  CREATE LOGIN adminGlobal WITH PASSWORD = N'gBkxlxF3pNhbD7Xxu5IIHoUCaXyuylh+XGn0DP4Uckc=', CHECK_POLICY = OFF;
  ALTER LOGIN adminGlobal DISABLE;
END

ALTER LOGIN [adminGlobal] DISABLE

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [adminSite]    Script Date: 11/06/2026 21:32:24 ******/
--CREATE LOGIN [adminSite] WITH PASSWORD=N'9arAuEfNCBZm1Pp8wBca49PLLREY4kVjtxkdUQwKG2M=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Français], CHECK_EXPIRATION=ON, CHECK_POLICY=ON

IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'adminSite')
BEGIN
  CREATE LOGIN [adminSite] WITH PASSWORD = N'9arAuEfNCBZm1Pp8wBca49PLLREY4kVjtxkdUQwKG2M=', CHECK_POLICY = OFF;
  ALTER LOGIN [adminSite] DISABLE;
END

ALTER LOGIN [adminSite] DISABLE

