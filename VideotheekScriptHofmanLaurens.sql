USE [master]
GO
/****** Object:  Database [VideotheekHofmanLaurens]    Script Date: 17/12/2017 13:38:29 ******/
CREATE DATABASE [VideotheekHofmanLaurens]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideotheekHofmanLaurens', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.LAURENSSQL\MSSQL\DATA\VideotheekHofmanLaurens.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideotheekHofmanLaurens_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.LAURENSSQL\MSSQL\DATA\VideotheekHofmanLaurens_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideotheekHofmanLaurens].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET  MULTI_USER 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET QUERY_STORE = OFF
GO
USE [VideotheekHofmanLaurens]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [VideotheekHofmanLaurens]
GO
/****** Object:  User [VideotheekHofmanLaurens]    Script Date: 17/12/2017 13:38:29 ******/
CREATE USER [VideotheekHofmanLaurens] FOR LOGIN [VideotheekHofmanLaurens] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [VideotheekHofmanLaurens]
GO
ALTER ROLE [db_datareader] ADD MEMBER [VideotheekHofmanLaurens]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [VideotheekHofmanLaurens]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17/12/2017 13:38:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVDs]    Script Date: 17/12/2017 13:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDs](
	[DVD_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[stock] [int] NOT NULL,
	[reserved_amount] [int] NULL,
	[price] [decimal](18, 2) NOT NULL,
	[director] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[PEGI_age] [int] NULL,
	[genres] [nvarchar](max) NULL,
	[DVD_type] [nvarchar](max) NULL,
	[movie_duration] [int] NULL,
	[series_episodes] [int] NULL,
	[created_at] [datetime] NOT NULL,
	[modified_at] [datetime] NOT NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_dbo.DVDs] PRIMARY KEY CLUSTERED 
(
	[DVD_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201712131422032_Stocks', N'VideotheekLibrary.Migrations.Configuration', 0x1F8B0800000000000400CD59DB6EE336107D2FD07F10F4D402592BC962816D60EFC2B59385D15C8C28C9AB414B63870845A92415D8DFB60FFDA4FE4287BA52946F7212A00810D843CE990B473C33F2BF3FFFE97F5F45CC79052169CC07EE59EFD47580077148F972E0A66AF1E9ABFBFDDBAFBFF42FC368E53C95FB3EEB7DA8C9E5C07D562AB9F03C193C4344642FA2818865BC50BD208E3C12C6DEF9E9E91FDED9990708E12296E3F4EF53AE6804D917FC3A8A7900894A09BB894360B290E38A9FA13AB7240299900006EE130D2156CF002FD7742E8858F7C64411D719324AD01B1FD8C27508E7B1220A7DBD7894E02B11F3A59FA080B0877502B86F41988422868B7AFBA1E19C9EEB70BC5AB1840A52A9E2A823E0D9E7223F9EAD7E5496DD2A7F98C14BCCB45AEBA8B32C0EDCF1D3D8756C3B172326F49E4DF9CD1028C81E6A9E38ADF593AA2CB07AF4DF89334A994A050C38A44A1076E24CD339A3C15FB07E885F800F78CA98E924BA896B0D018AA6224E40A8F53D2C0AD727E8B9D7D4F36CC54ACDD0C9239B70F5F9DC756ED1389933A86AC0C882AF62013F8083200AC229510A041EE124842C8B2DEB962DFDBFB4864587CF90EBDC90D535F0A57A1EB8E75FBEB8CE155D41584A0A0F1E39C5470E959448618387BBADA2D3C1CBBE2077430C5F09CDF66FC2DAAD7A0F12C42B84C328C687FA6D6E4C050DAA048E21A01161AE3315F8A9B89FBEBA8E1F100DD81D7D4C11080F78C709E1C7834E688F219081A049FEFC7EB0ADE9E58F095942A723C30217203F3E0D4F636DE1C3EDDCC4AF14C6A92066C20F4A840F02EFB5CB844A34263BA98E04E82B6258553CB2103CD0A8FBE38B944717F45DA0C6C0608B53A662DFAB49A14D1548C68A50BC02CBBB2149C6732D8495DA401CC8AF0577C8E2B89A2EE6A03EA8BA2A30D3B5033965F73256DAE464E54EDD1478795750760FDE96F6A17F4392044BCE68270A89E3E7BDC4E893DF9D60A31CC30BE4069EADBCAD2CE18583CFA7B58AA6D1D32B2AA4D2DDCB9CE8B31D85516B5B23F95B125B9A32F26B53699DEE72B3FE9C2B6C6EA8B203B160EA045E614C117262161E549EE4CD454B2BEBE308236203358F629646BC727D4643BBC87721E4846B62706257FB6E8482F04C08998B0EC7B0D9D30423E5DAAC33ACCDAC26AC28D666A4583C1CB62059132DC9458763D4546AC28495B40392C9950D3073A14374251F9A585A38CBA48703952469E22C0B5987F04A0EB4EB5C65D2C3812C9233E122BD340BABB50EC56FF15FE329C8D666502D1E0E6B70A38918E4E219E954AE263D36A3CEE51DE10C8A6C565B26DE02D6F7AC7BCFBE5FBDD6056B4D29F665BD8BE8EC2D95F58AF02C62EB1724B37F786EB14EBE45F7D85844A1661C7F2D15443907F87FB311A3A0EF9772C30DE1740152E5839C8BB3EBB9357BFF7FE6604FCA90ED1F868F18443733D5FE61B4D4CB1B1FAA13BB77E4ECD803726306E5AF4404CF44B4A7D08EA0D21C0B33B73B02B4687023D421DD7E8BF98E772A31C7CDF0BDC7CDD01A37CBC3F82D22ABDFBB461DB647CA37E1D58C78F4412C1B53E49BBCA909F11DC06C3A3C3AC016031E8D64325F516DF85D1D33E23568EF8D5826E96D876A07D86D7E6C4F3A7B07C46DF361CE56E8E63C468F73F7F279F2C8C9B14D9C7DCF7C37DDC7F6942E6B08FDA69AE3538D855583967B267C119719C6704C8FCA2D766F038A60CAC95028BA2081C2E500A4CC5E933C1196E296CB680EE184DFA52A49D5504A88E6ACF11EB2EFEDB69F8DC74D9FFB77D94522DF23047493EAAAB9E37FA6948595DF57ED02DC06A10BA42040F4CA579A0897EB0AE936E6070215E91B43025CD3E7034409433079C77DF20AC7F8F628E11A96245897FDCF7690FD07D14C7B7F4CC95290481618B5BEFEBDC5D33FB87CFB0FBABFB0F1A2190000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201712131431502_StocksInt', N'VideotheekLibrary.Migrations.Configuration', 0x1F8B0800000000000400CD59DB6EE336107D2FD07F10F4D402592BC962816D60EFC2B59385D15C8C28C9AB414B63870845A92415D8DFB60FFDA4FE4287BA52946F7212A00810D843CE990B473C33F2BF3FFFE97F5F45CC79052169CC07EE59EFD47580077148F972E0A66AF1E9ABFBFDDBAFBFF42FC368E53C95FB3EEB7DA8C9E5C07D562AB9F03C193C4344642FA2818865BC50BD208E3C12C6DEF9E9E91FDED9990708E12296E3F4EF53AE6804D917FC3A8A7900894A09BB894360B290E38A9FA13AB7240299900006EE130D2156CF002FD7742E8858F7C64411D719324AD01B1FD8C27508E7B1220A7DBD7894E02B11F3A59FA080B0877502B86F41988422868B7AFBA1E19C9EEB70BC5AB1840A52A9E2A823E0D9E7223F9EAD7E5496DD2A7F98C14BCCB45AEBA8B32C0EDCF1D3D8756C3B172326F49E4DF9CD1028C81E6A9E38ADF593AA2CB07AF4DF89334A994A050C38A44A1076E24CD339A3C15FB07E885F800F78CA98E924BA896B0D018AA6224E40A8F53D2C0AD727E8B9D7D4F36CC54ACDD0C9239B70F5F9DC756ED1389933A86AC0C882AF62013F8083200AC229510A041EE124842C8B2DEB962DFDBFB4864587CF90EBDC90D535F0A57A1EB8E75FBEB8CE155D41584A0A0F1E39C5470E959448618387BBADA2D3C1CBBE2077430C5F09CDF66FC2DAAD7A0F12C42B84C328C687BA93EA54D0A0CAD718021A11E63A53819F8AEBE8ABEBF801D161748F694C1108CF73C781E0C7830E648F219081A049FEB87EB0ADE9E58F095942A734633D0B901F9F86A7B1B6F0E1766EE2570AE3541033E10725C20781D7D86542251A939D544702F48D30AC0A1C49071E68D4FD694586A30BFA2E506360B0C52953B1EFD51CD06606E45E4528DE78E5559024E3B916C24A6DE009A4D3822A64715C4D1773501F545D1598E9DA819CA17B19096D72B272A7EE01BCBC09289B056F4BB7D0BF2149822567740F85C4F1F3D661F4C9EFCEA7518EE1057203AD56DE5696F0C2C1E7D35A45D3E8E9151552E966654EF4D98EC2A8B5AD91FC2D892D4D19F9B599B34E77B9597FCE1536F74FD98158307502AF30A60829300B0F2A4FF25EA2A595B56D8411B1818947314B235EB93EA3A15DE4BB10727E353138B1AB7D3742C16F2684CC458763D864698291726DD619D626521356146B33522C1E0E5B90AC8996E4A2C3316A2A3561C24ADA01C9E4CA0698B9D021BA920F4D2C2D9C65D2C3814A9234719685AC43782507DA75AE32E9E14016C99970915E9A85D55A87E2B7F8AFF114646B33A8160F8735B8D1440C72F18C742A57931E9B51E7F28E70064536AB2D136F01EB7BD6BD67DFAF5EEB82B58612FBB2DE4574F696CA7A457816B1F50B92D93F2BB75827DFA27B6C2CA250338EBF960AA29C03FCBFD98851D0F74BB9E18670BA00A9F2B9CDC551F5DC1AB5FF3F63AF2765C8F6CFBE47CC9D9B996AFFEC59EAE58D0FD589DD3B6176EC01B93172F25722826722DA43674750694E8199DB1D015A34B811EA906EBFC57C472325E6B419BEF7B4195AD3667916BF4564F57B5757C3F644F926BC9A108FCEDEB23144BEC99B9A0FDF01CC66C3A3036C11E0D14826F115D586DFD531135E83F5DE886572DE76A87680DDC6C7F6A0B3773EDC361EE664856ECE63F438772F1F278F1C1CDBBCD9F7CC37D17DEC4EE9B286D0EFA5393ED558583568B967C2177199610CC7F4A8DC62B736A008A69C0C85A20B12285C0E40CAEC2DC91361296EB98CE6104EF85DAA92540DA58468CE1A6F1DFBDE6EFBD974DCF4B97F975D24F23D424037A9AE9A3BFE674A5958F97DD52EC06D10BA400AFE43AF7CA57970B9AE906E637E205091BE3124C0357B3E409430049377DC27AF708C6F8F12AE61498275D9FE6C07D97F10CDB4F7C7942C0589648151EBEB5F573CFDF3CAB7FF006BE08D1A90190000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201712131511383_calculationstock', N'VideotheekLibrary.Migrations.Configuration', 0x1F8B0800000000000400CD59DB6EE336107D2FD07F10F4D402592BC962816D60EFC2B59385D15C8C28C9AB414B63870845A92415D8DFB60FFDA4FE4287BA52946F7212A00810D843CE99C3D1908723FFFBF39FFEF755C49C571092C67CE09EF54E5D07781087942F076EAA169FBEBADFBFFDFA4BFF328C56CE5339EFB39E879E5C0EDC67A5920BCF93C1334444F6221A8858C60BD50BE2C82361EC9D9F9EFEE19D9D7980102E62394EFF3EE58A46907DC1AFA3980790A894B09B3804260B3B8EF819AA734B2290090960E03ED11062F50CF0724DE78288756F4C14719D21A304D9F8C016AE43388F1551C8F5E25182AF44CC977E8206C21ED609E0BC0561128A355CD4D30F5DCEE9B95E8E573B9650412A551C75043CFB5CE4C7B3DD8FCAB25BE50F33788999566BBDEA2C8B0377FC34761D3BCEC588093D67537E33040AB2879E274E6BFCA42A0BAC1EFD77E28C52A65201030EA912849D38D374CE68F017AC1FE217E0039E326692449A38D630A0692AE204845ADFC3A2A03E41E65ED3CFB31D2B37C3275FD984ABCFE7AE738BC1C99C41550346167C150BF8011C0451104E895220F0114E42C8B2D88A6EC5D2FFCB685874B8875CE786ACAE812FD5F3C03DFFF2C575AEE80AC2D2523078E414B71C3A2991C20686BBA322E9E065DF227743DC8304F10AE1308A71675A58BB5DA78206D5A2C710D08830D7990AFC549C295F5DC70F88E6D29DD89822103E941D59C58F0765754F209081A049BEE73E38D6F4F2C7842CA1539AB12805C88F4FC3D35847F8F03837F12B85712A8899F08312E183C0B3E832A11283C94EAE23017A5B0FAB0247E580071A75DF7228537441DF056A0C0CB690321DFB5E7D90B78F77145045281E5B05E83049C6736D8495DA70D8A32616E7BD2C1E5793620EEA83AAAB02335D13C865B69729C92692159D5AC8BD5CC94BC5F7B6487EFF862409969C7105282C8E9FEBFFE893DF5D14A31CC30BE4066DACD85691F0C0C1FD698D6268647A458554FAC63127FAD98EC2A835AD91FC2D892D4319F9B5E5AF4E7739597FCE1D365F82B20762C1D409BCC23545A863D9F2A062925F085A5ED9DD8B302236C8E9286669C42BEA331ADA45BE0B211749138313BBDA772314826742C8DC743886AD78269828C666A4183C1CB65043132DC94D8763D49A67C28495B50392296A0D3073A0C3EA4AE132B1B47196590F072AD5CCC45916B60ECB2BC5CA2E4895590F07B2D4C8848BF4D02CACC63A54A925548D72CDC666500D1E0E6B88988918E4E619E954AEA68E35579DDB3BC2195AD6ACB6CCBC05ACEF5907947D107AAD93D06A01EC53759722D953AAE89532590AD42FD4607F67DA92877C8ABE0C6311855A1AFCB55410E587B5FF371B310AFA7C2927DC104E172055DE25B9D8189E5B8DEDFFA7C9F4A40CD9FE4EF3882E6FB3A4ECEFF44ABFFC86427562F7F6731D2F6BDC68F0F82B11C13311ED16AF23A834FBB78C764780965E6D843AE45A9E98CD5CF8DECD5C68357365067F8BC8EAF7AE54C376C3F626BC5AC68ECEDEB2D1A3BD894DAD62EF00666BD8D10B6CC9D6D148A65C15D586DFD5310D5443ABDE88652AD576A8F602BB7567ED3E626FFBB5ADFBCA250669CE63649CD3CBBBB523FBB2B6DAF53DF36D6D1FEF94745943E877B71C773516560D5ACE99F0455C66189763322AA7D817125004534E8642D10509140E072065F612E289B014A75C46730827FC2E5549AA86524234678D37737D6F77FCACF96C72EEDF6507897C8F25204DAAABE68EFF99521656BCAFDA05B80D421748A15AC8CA575ABD96EB0AE936E6070215E91B43025C6BDE034409433079C77DF20AC7707B94700D4B12ACCB4BCB7690FD0FA299F6FE9892A520912C306A7FFD0B84A77F82F8F61F63A0265FB4180000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201712131919599_yt', N'VideotheekLibrary.Migrations.Configuration', 0x1F8B0800000000000400CD59DB6EE336107D2FD07F10F4D402592BC962816D20EFC2B59345D0DC102501FA64D0D2D82142512A4905F6B7F5A19FD45FE850578AF24D4E021401027BC83973D1906746FEF7EF7FFCEFCB9839AF20244DF8D03D191CBB0EF03089285F0CDD4CCD3F7D75BF7FFBF927FF3C8A97CE53B5EFB3DE879A5C0EDD67A5D233CF93E133C4440E621A8A442673350893D82351E29D1E1FFFE69D9C7880102E62398E7F9F714563C8BFE0D771C243485546D875120193A51C57821CD5B92131C8948430749F6804897A0678B9A23341C46A30218AB8CE885182DE04C0E6AE43384F1451E8EBD9A3844089842F821405843DAC52C07D73C22494319C35DBF70DE7F85487E3358A1554984995C43D014F3E97F9F16CF583B2ECD6F9C30C9E63A6D54A479D6771E84E9E26AE63DB391B33A1F7ACCB6F8E40410E50F3C8E9AC1FD56581D5A3FF8E9C71C6542660C8215382B023E72E9B311AFE01AB87E405F890678C994EA29BB8D612A0E84E242908B5BA8779E9FA257AEEB5F53C5BB15633748AC82EB9FA7CEA3A37689CCC18D4356064215089801FC0411005D11D510A043EC2CB08F22C76AC5BB6F4FFCA1A161D9E21D7B926CB2BE00BF53C744FBF7C719D0BBA84A892941E3C728A470E9594C8608D87DBADA2D3E1CBAE20B743DC8304F10AD1284EF0645A58DB55FF7CD812317EDC2BE2ED26EE040DEBBC4E20A43161AE7327F053796D7D759D20243ADCFEB14F2802E173FFF03026204341D3E2587F74CACE7F5C9205F47A9258F702E4C7A7E169A22D7CB89DEBE495C22413C44CF85E890840E075779E5289C6642FD5B1007D738CEA3384E4040F34EE7FAA9109E99CBE0BD404186C70CA54F4BD862BBA0C821CAD08C59BB1041DA5E964A685B0546BF80469B7A414593EAEB68B056800AAA90ACC74E340C1E4839CACD63959BBD3F40A5ED12C544D85B7A1ABF0AF499A62C9195D46297182A2C5187F0AFAF36E5C6078A15C43BFB5B7B525BC70F07C5AAB681A3DBDA0422ADDD4CC887EB6E328EE6C6B257F43622B53467E6D866DD25D6DD69F0B85F57D56FE402C9826811718538C54998707B52745CFD1D1CADB3BC28858C3D8E3846531AF5D9FD2C82EF26D08050F9B189CD8D5BE1DA1E454134216A2FD316C5235C144B93625E5E2FEB09A704DA8552FED924B4D80B410ED8FD130A60913D5D21E482625B6C0CC851ED155B4676269E13497EE0F5471A189B328653DC2ABA8CE2E67954BF707B2B8CC848BF5D234AAD77AD4B84573AD62CFD7A6502FEE0F6B50A0891816E229E955AE260BB6A32EE43DE10C266C575B2EDE00E67BD6F5665FA35EE71EB56614FB4EDEC667F696DA7ACD6B167FF92597EC1E9D3BE4526CD1AD341651A489255849057171D5077FB131A3A06FA76AC335E1740E5215639C8B93EBA93579FF7FA6604FCA88ED1E850F1843D713D2EE51B4D22BFA1BAA13BB73E0ECD9EA716302E5AF4484CF447467D09EA0D21C3073B77B0274D86E2DD43E4DFD4AD9D1FD1293E5AF7D615273A28CDE7BA28CAC89F24DAE46DDA9F14D780D1B1EFC1016AD41F14DDE3464F80E6036151E1C6087FD0E463259AFAC36FCAE0E99E25A94F7462C93F036437503EC37227687999D33E0A611B0602A747396A0C7857BC5C878E070D8254DDF33DF4AFBD89AD24503A1DF51733CD558580D68B5E792CF932AC3188EE951B5C5EE6B40114C39190945E72454B81C8294F99B9027C232DC721ECF20BAE4B7994A33359212E2196BBD81F4BDEDF6F309B8EDB37F9B5F24F23D424037A9AE9A5BFE7B465954FB7DD12DC04D10BA404AF243AF02A54970B1AA916E12BE275099BE09A4C035753E409C320493B73C20AF70886F8F12AE6041C255D5FB6C06D9FD20DA69F727942C04896589D1E8EB5F5A3CFD53CBB7FF004C062F2D9C190000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201712132021321_noYT', N'VideotheekLibrary.Migrations.Configuration', 0x1F8B0800000000000400CD59DB6EE336107D2FD07F10F4D402592BC962816D60EFC2B59385D15C8C28C9AB414B63870845A92415D8DFB60FFDA4FE4287BA52946F7212A00810D843CE99C3D1908723FFFBF39FFEF755C49C571092C67CE09EF54E5D07781087942F076EAA169FBEBADFBFFDFA4BFF328C56CE5339EFB39E879E5C0EDC67A5920BCF93C1334444F6221A8858C60BD50BE2C82361EC9D9F9EFEE19D9D7980102E62394EFF3EE58A46907DC1AFA3980790A894B09B3804260B3B8EF819AA734B2290090960E03ED11062F50CF0724DE78288756F4C14719D21A304D9F8C016AE43388F1551C8F5E25182AF44CC977E8206C21ED609E0BC0561128A355CD4D30F5DCEE9B95E8E573B9650412A551C75043CFB5CE4C7B3DD8FCAB25BE50F33788999566BBDEA2C8B0377FC34761D3BCEC588093D67537E33040AB2879E274E6BFCA42A0BAC1EFD77E28C52A65201030EA912849D38D374CE68F017AC1FE217E0039E326692449A38D630A0692AE204845ADFC3A2A03E41E65ED3CFB31D2B37C3275FD984ABCFE7AE738BC1C99C41550346167C150BF8011C0451104E895220F0114E42C8B2D88A6EC5D2FFCB685874B8875CE786ACAE812FD5F3C03DFFF2C575AEE80AC2D2523078E414B71C3A2991C20686BBA322E9E065DF227743DC8304F10AE1308A71675A58BB5DA78206D5A2C710D08830D7990AFC549C295F5DC70F88E6D29DD89822103E941D59C58F0765754F209081A049BEE73E38D6F4F2C7842CA1539AB12805C88F4FC3D35847F8F03837F12B85712A8899F08312E183C0B3E832A11283C94EAE23017A5B0FAB0247E580071A75DF7228537441DF056A0C0CB690321DFB5E7D90B78F77145045281E5B05E83049C6736D8495DA70D8A32616E7BD2C1E5793620EEA83AAAB02335D13C865B69729C92692159D5AC8BD5CC94BC5F7B6487EFF862409969C7105282C8E9FEBFFE893DF5D14A31CC30BE4066DACD85691F0C0C1FD698D6268647A458554FAC63127FAD98EC2A835AD91FC2D892D4319F9B5E5AF4E7739597FCE1D365F82B20762C1D409BCC23545A863D9F2A062925F085A5ED9DD8B302236C8E9286669C42BEA331ADA45BE0B211749138313BBDA772314826742C8DC743886AD78269828C666A4183C1CB65043132DC94D8763D49A67C28495B50392296A0D3073A0C3EA4AE132B1B47196590F072AD5CCC45916B60ECB2BC5CA2E4895590F07B2D4C8848BF4D02CACC63A54A925548D72CDC666500D1E0E6B88988918E4E619E954AEA68E35579DDB3BC2195AD6ACB6CCBC05ACEF5907947D107AAD93D06A01EC53759722D953AAE89532590AD42FD4607F67DA92877C8ABE0C6311855A1AFCB55410E587B5FF371B310AFA7C2927DC104E172055DE25B9D8189E5B8DEDFFA7C9F4A40CD9FE4EF3882E6FB3A4ECEFF44ABFFC86427562F7F6731D2F6BDC68F0F82B11C13311ED16AF23A834FBB78C764780965E6D843AE45A9E98CD5CF8DECD5C68357365067F8BC8EAF7AE54C376C3F626BC5AC68ECEDEB2D1A3BD894DAD62EF00666BD8D10B6CC9D6D148A65C15D586DFD5310D5443ABDE88652AD576A8F602BB7567ED3E626FFBB5ADFBCA250669CE63649CD3CBBBB523FBB2B6DAF53DF36D6D1FEF94745943E877B71C773516560D5ACE99F0455C66189763322AA7D817125004534E8642D10509140E072065F612E289B014A75C46730827FC2E5549AA86524234678D37737D6F77FCACF96C72EEDF6507897C8F25204DAAABE68EFF99521656BCAFDA05B80D421748A15AC8CA575ABD96EB0AE936E6070215E91B43025C6BDE034409433079C77DF20AC7707B94700D4B12ACCB4BCB7690FD0FA299F6FE9892A520912C306A7FFD0B84A77F82F8F61F63A0265FB4180000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[DVDs] ON 

INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (6, N'Star Wars: Episode I - The Phantom Menace', 15, 4, CAST(20.00 AS Decimal(18, 2)), N'George Lucas ', N'Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to claim their old glory. ', NULL, N'Action, Adventure, Fantasy', N'Movie', 136, NULL, CAST(N'2017-12-14T20:04:08.993' AS DateTime), CAST(N'2017-12-14T20:04:08.993' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (7, N'Star Wars: Episode II - Attack of the Clones', 12, 1, CAST(12.00 AS Decimal(18, 2)), N'George Lucas', N'Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with Padmé, while Obi-Wan investigates an assassination attempt on the Senator and discovers a secret clone army crafted for the Jedi. ', NULL, N'Action, Adventure, Fantasy', N'Movie', 142, NULL, CAST(N'2017-12-14T20:06:59.497' AS DateTime), CAST(N'2017-12-14T20:06:59.497' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (8, N'Star Wars: Episode III - Revenge of the Sith', 15, 7, CAST(9.00 AS Decimal(18, 2)), N'George Lucas', N'Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan pursues a new threat, Anakin acts as a double agent between the Jedi Council and Palpatine and is lured into a sinister plan to rule the galaxy. ', 13, N'Action, Adventure, Fantasy', N'Movie', 140, NULL, CAST(N'2017-12-14T20:07:48.593' AS DateTime), CAST(N'2017-12-14T20:07:48.593' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (9, N'Star Wars: Episode IV - A New Hope', 44, 0, CAST(4.00 AS Decimal(18, 2)), N'George Lucas', N'Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire''s world-destroying battle-station while also attempting to rescue Princess Leia from the evil Darth Vader.', NULL, N'Action, Adventure, Fantasy', N'Movie', 121, NULL, CAST(N'2017-12-14T20:09:03.957' AS DateTime), CAST(N'2017-12-14T20:09:03.957' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (10, N'Star Wars: Episode V - The Empire Strikes Back', 5, 0, CAST(55.00 AS Decimal(18, 2)), N'Irvin Kershner', N'After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Yoda. His friends accept shelter from a questionable ally as Darth Vader hunts them in a plan to capture Luke. ', NULL, N'Action, Adventure, Fantasy', N'Movie', 124, NULL, CAST(N'2017-12-14T20:13:55.403' AS DateTime), CAST(N'2017-12-14T20:13:55.403' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (11, N'Star Wars: Episode VI - Return of the Jedi', 6, 6, CAST(16.00 AS Decimal(18, 2)), N'Richard Marquand', N'After a daring mission to rescue Han Solo from Jabba the Hutt, the rebels dispatch to Endor to destroy a more powerful Death Star. Meanwhile, Luke struggles to help Vader back from the dark side without falling into the Emperor''s trap. ', NULL, N'Action, Adventure, Fantasy', N'Movie', 131, NULL, CAST(N'2017-12-14T20:14:40.587' AS DateTime), CAST(N'2017-12-14T20:14:40.587' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (12, N'Rogue One', 1, 1, CAST(11.00 AS Decimal(18, 2)), N'Gareth Edwards', N'The daughter of an Imperial scientist joins the Rebel Alliance in a risky move to steal the Death Star plans. ', 13, N'Action, Adventure, Sci-Fi ', N'Movie', 133, NULL, CAST(N'2017-12-14T20:18:01.493' AS DateTime), CAST(N'2017-12-14T20:18:01.493' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (13, N'Star Wars: The Force Awakens', 17, 0, CAST(77.00 AS Decimal(18, 2)), N'J.J. Abrams', N'Three decades after the Empire''s defeat, a new threat arises in the militant First Order. Stormtrooper defector Finn and spare parts scavenger Rey are caught up in the Resistance''s search for the missing Luke Skywalker. ', 13, N'Action, Adventure, Fantasy', N'Movie', 136, NULL, CAST(N'2017-12-14T20:18:45.113' AS DateTime), CAST(N'2017-12-14T20:18:45.113' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (14, N'Star Wars: The Last Jedi', 100, 2, CAST(300.00 AS Decimal(18, 2)), N'Rian Johnson', N'Having taken her first steps into the Jedi world, Rey joins Luke Skywalker on an adventure with Leia, Finn and Poe that unlocks mysteries of the Force and secrets of the past. ', 13, N'Action, Adventure, Fantasy', N'Movie', 156, NULL, CAST(N'2017-12-14T20:20:07.570' AS DateTime), CAST(N'2017-12-14T20:20:07.570' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (15, N'Stranger Things (Season 1)', 69, 0, CAST(10.00 AS Decimal(18, 2)), N'Matt Duffer, Ross Duffer ', N'When a young boy disappears, his mother, a police chief, and his friends must confront terrifying forces in order to get him back. ', 14, N'Drama, Fantasy, Horror', N'TV-Series', NULL, 8, CAST(N'2017-12-14T20:21:22.297' AS DateTime), CAST(N'2017-12-14T20:21:22.297' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (16, N'Vikings (Season 2)', 20, 5, CAST(10.00 AS Decimal(18, 2)), N'Michael Hirst', N'The world of the Vikings is brought to life through the journey of Ragnar Lothbrok, the first Viking to emerge from Norse legend and onto the pages of history - a man on the edge of myth. ', 14, N'Action, Drama, History', N'TV-Series', NULL, 10, CAST(N'2017-12-14T20:23:05.757' AS DateTime), CAST(N'2017-12-14T20:23:05.757' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (17, N'Dark', 5, 0, CAST(9.00 AS Decimal(18, 2)), N'Baran bo Odar, Jantje Friese ', N'Peter gets a shock. Jonas learns the truth about his family, but there are more surprises still to come. Helge makes a sacrifice.', 17, N'Crime, Drama, Mystery', N'TV-Series', NULL, 10, CAST(N'2017-12-14T20:25:15.993' AS DateTime), CAST(N'2017-12-14T20:25:15.993' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (18, N'Indiana Jones and the Temple of Doom', 20, 3, CAST(10.00 AS Decimal(18, 2)), N'Steven Spielberg', N'After arriving in India, Indiana Jones is asked by a desperate village to find a mystical stone. He agrees, and stumbles upon a secret cult plotting a terrible plan in the catacombs of an ancient palace. ', NULL, N'Action, Adventure', N'Movie', 118, NULL, CAST(N'2017-12-14T20:27:10.177' AS DateTime), CAST(N'2017-12-14T20:27:10.177' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (19, N'Jurassic Park', 5, 2, CAST(21.00 AS Decimal(18, 2)), N'Steven Spielberg', N'During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok. ', 13, N'Adventure, Sci-Fi, Thriller', N'Movie', 127, NULL, CAST(N'2017-12-14T20:27:52.647' AS DateTime), CAST(N'2017-12-14T20:27:52.647' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (20, N'Saving Private Ryan', 1944, 5, CAST(6.00 AS Decimal(18, 2)), N'Steven Spielberg', N'Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.', 17, N'Drama, War', N'Movie', 169, NULL, CAST(N'2017-12-14T20:29:10.767' AS DateTime), CAST(N'2017-12-14T20:29:10.767' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (21, N'The Walking Dead (Season 3)', 3, 2, CAST(3.00 AS Decimal(18, 2)), N'Frank Darabont', N'Sheriff Deputy Rick Grimes wakes up from a coma to learn the world is in ruins, and must lead a group of survivors to stay alive. ', 17, N'Drama, Horror, Thriller', N'TV-Series', NULL, 16, CAST(N'2017-12-14T20:32:27.787' AS DateTime), CAST(N'2017-12-14T20:32:27.787' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (25, N'Gremlin', 18, 0, CAST(15.00 AS Decimal(18, 2)), N'Ryan Bellgardt', N'A man receives a mysterious box containing a terrible secret, a creature that will kill everyone else in his family unless he passes it on to someone he loves to continue its never-ending circulation.', 18, N'Horror', N'Movie', 90, NULL, CAST(N'2017-12-17T12:52:41.753' AS DateTime), CAST(N'2017-12-17T12:52:41.753' AS DateTime), NULL)
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (26, N'zf', 20, 0, CAST(20.00 AS Decimal(18, 2)), NULL, N'fe', NULL, NULL, NULL, NULL, NULL, CAST(N'2017-12-17T12:53:33.270' AS DateTime), CAST(N'2017-12-17T12:53:33.270' AS DateTime), CAST(N'2017-12-17T12:54:00.457' AS DateTime))
INSERT [dbo].[DVDs] ([DVD_id], [name], [stock], [reserved_amount], [price], [director], [description], [PEGI_age], [genres], [DVD_type], [movie_duration], [series_episodes], [created_at], [modified_at], [deleted_at]) VALUES (27, N'zfdf', 30, 0, CAST(20.00 AS Decimal(18, 2)), NULL, N'gzf', NULL, NULL, NULL, NULL, NULL, CAST(N'2017-12-17T12:53:41.940' AS DateTime), CAST(N'2017-12-17T12:53:41.940' AS DateTime), CAST(N'2017-12-17T12:54:02.183' AS DateTime))
SET IDENTITY_INSERT [dbo].[DVDs] OFF
USE [master]
GO
ALTER DATABASE [VideotheekHofmanLaurens] SET  READ_WRITE 
GO
