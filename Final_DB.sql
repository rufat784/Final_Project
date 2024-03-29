USE [Resido]
GO
SET IDENTITY_INSERT [dbo].[BathroomCounts] ON 

INSERT [dbo].[BathroomCounts] ([Id], [CountName]) VALUES (1, N'1')
INSERT [dbo].[BathroomCounts] ([Id], [CountName]) VALUES (2, N'2')
INSERT [dbo].[BathroomCounts] ([Id], [CountName]) VALUES (3, N'3')
INSERT [dbo].[BathroomCounts] ([Id], [CountName]) VALUES (11, N'4')
SET IDENTITY_INSERT [dbo].[BathroomCounts] OFF
GO
SET IDENTITY_INSERT [dbo].[BedroomsCounts] ON 

INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (1, N'1')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (2, N'2')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (3, N'3')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (4, N'4')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (5, N'5')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (6, N'6')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (7, N'7')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (9, N'8+')
INSERT [dbo].[BedroomsCounts] ([Id], [CountName]) VALUES (12, N'213123')
SET IDENTITY_INSERT [dbo].[BedroomsCounts] OFF
GO
SET IDENTITY_INSERT [dbo].[BuildingAges] ON 

INSERT [dbo].[BuildingAges] ([Id], [Years]) VALUES (1, N'10-20')
INSERT [dbo].[BuildingAges] ([Id], [Years]) VALUES (2, N'20-30')
INSERT [dbo].[BuildingAges] ([Id], [Years]) VALUES (3, N'30-40')
INSERT [dbo].[BuildingAges] ([Id], [Years]) VALUES (4, N'40-50')
INSERT [dbo].[BuildingAges] ([Id], [Years]) VALUES (5, N'50+')
SET IDENTITY_INSERT [dbo].[BuildingAges] OFF
GO
SET IDENTITY_INSERT [dbo].[CityOfProperties] ON 

INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (1, N'Baku', N'4ec30605-d20f-4212-9c5d-8992b42f7032-13.07.2021.14.22.08-c-1.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (2, N'Sumqait', N'f5735400-4c73-496e-8b71-b3d0a6399f34-13.07.2021.14.22.18-c-2.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (3, N'Quba', N'1d9c3fd2-19d7-498f-a1dd-d7db41fa41e7-13.07.2021.14.22.26-c-3.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (4, N'Qusar', N'8230e3ea-78f2-4500-91fd-5c8eb4f59c31-13.07.2021.14.22.34-c-4.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (5, N'Ucar', N'9dc281fe-26ac-4790-9c6b-51ac61a71cf9-13.07.2021.14.22.43-c-5.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (6, N'Yevlax', N'2b93e967-4b51-4d97-a8eb-38d45c431839-13.07.2021.14.22.52-c-6.png')
INSERT [dbo].[CityOfProperties] ([Id], [Name], [Image]) VALUES (29, N'madrid', N'74341bba-ddff-4f8e-9bd1-950f53cfe7ad-14.08.2021.12.58.56-c-5.png')
SET IDENTITY_INSERT [dbo].[CityOfProperties] OFF
GO
SET IDENTITY_INSERT [dbo].[GarageCounts] ON 

INSERT [dbo].[GarageCounts] ([Id], [CountName]) VALUES (1, N'-')
INSERT [dbo].[GarageCounts] ([Id], [CountName]) VALUES (2, N'1')
INSERT [dbo].[GarageCounts] ([Id], [CountName]) VALUES (3, N'2')
SET IDENTITY_INSERT [dbo].[GarageCounts] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyStatuses] ON 

INSERT [dbo].[PropertyStatuses] ([Id], [Name]) VALUES (1, N'For Rent')
INSERT [dbo].[PropertyStatuses] ([Id], [Name]) VALUES (2, N'For Sale')
INSERT [dbo].[PropertyStatuses] ([Id], [Name]) VALUES (3, N'For Monthly rent')
SET IDENTITY_INSERT [dbo].[PropertyStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyTypes] ON 

INSERT [dbo].[PropertyTypes] ([Id], [Name]) VALUES (1, N'Flat')
INSERT [dbo].[PropertyTypes] ([Id], [Name]) VALUES (2, N'Mansion')
INSERT [dbo].[PropertyTypes] ([Id], [Name]) VALUES (3, N'Castle')
INSERT [dbo].[PropertyTypes] ([Id], [Name]) VALUES (4, N'Small House')
SET IDENTITY_INSERT [dbo].[PropertyTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[RegistrationOptionSelects] ON 

INSERT [dbo].[RegistrationOptionSelects] ([Id], [OptionSelect]) VALUES (1, N'Agent')
INSERT [dbo].[RegistrationOptionSelects] ([Id], [OptionSelect]) VALUES (2, N'Agency')
INSERT [dbo].[RegistrationOptionSelects] ([Id], [OptionSelect]) VALUES (3, N'Customer')
SET IDENTITY_INSERT [dbo].[RegistrationOptionSelects] OFF
GO
SET IDENTITY_INSERT [dbo].[MyProfileForAgents] ON 

INSERT [dbo].[MyProfileForAgents] ([Id], [ProfileImage], [OwnerName], [Password], [State], [Email], [YourPosition], [Phone], [Adress], [City], [ZipCode], [About], [IsAgency], [CompanySize], [CompanyStatus], [RegistrationOptionSelectId], [Token], [AddedDAte]) VALUES (38, N'168abb83-5e7a-438e-b1ee-93679ccaae7b-15.07.2021.16.44.54-user-3.jpg', N'Karim Benzema', N'$2a$11$zTSC3/KtRWWwepNNZwvNTukMetsc.BmOHLABA95R8.6Mv93KdT2RK', N'Azerbaijan', N'rufatzz@code.edu.az', N'Agent and CEO', N'0708777889', N'Merdanov Qar. 112', N'Baku', N'AZ1000', N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content ', 0, NULL, NULL, 1, N'dfdsfqwerwerwerdsf', CAST(N'2020-09-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MyProfileForAgents] ([Id], [ProfileImage], [OwnerName], [Password], [State], [Email], [YourPosition], [Phone], [Adress], [City], [ZipCode], [About], [IsAgency], [CompanySize], [CompanyStatus], [RegistrationOptionSelectId], [Token], [AddedDAte]) VALUES (42, N'292355b0-caf6-4d0a-b5fb-2dfeb0cf3d07-01.07.2021.08.48.02-ag-7.png', N'Roof for life', N'$2a$11$icfinNBqHWt.XuB1eZ1/se59x5IWvtIFaRBTDtxJgnhCPmEvKK0iK', N'Azerbaijan', N'roof@gmail.com', N'Agency', N'0555666723', N'Nobel pr', N'Baku', N'AZ1022', N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content ', 1, N'120', N'Available', 2, NULL, CAST(N'2020-07-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MyProfileForAgents] ([Id], [ProfileImage], [OwnerName], [Password], [State], [Email], [YourPosition], [Phone], [Adress], [City], [ZipCode], [About], [IsAgency], [CompanySize], [CompanyStatus], [RegistrationOptionSelectId], [Token], [AddedDAte]) VALUES (43, N'bc4a7b84-0ab2-48c9-b010-4648ac845738-05.07.2021.15.08.23-team-1.jpg', N'Emre Akinci', N'$2a$11$y4K5uV0N0vXX6tCz8GcYu..y2tTPJiRYAqPPCT5YZ124p6G6HGEgG', N'Azerbaijan', N'emre@gmail.com', N'Customer', N'0515610399', NULL, N'Baku', NULL, NULL, 0, NULL, NULL, 3, NULL, CAST(N'2020-08-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MyProfileForAgents] ([Id], [ProfileImage], [OwnerName], [Password], [State], [Email], [YourPosition], [Phone], [Adress], [City], [ZipCode], [About], [IsAgency], [CompanySize], [CompanyStatus], [RegistrationOptionSelectId], [Token], [AddedDAte]) VALUES (54, NULL, N'ggg', N'$2a$11$iwfiO7jETMLtCzRYJYJ7YuaqL.kaj1wTSU1naSRFY.GDaIuPYD6Ze', NULL, N'ggg@gmail.com', NULL, N'12333333', NULL, NULL, NULL, NULL, 0, NULL, NULL, 1, NULL, CAST(N'2021-08-14T13:16:36.5222912' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MyProfileForAgents] OFF
GO
SET IDENTITY_INSERT [dbo].[Property2] ON 

INSERT [dbo].[Property2] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [Price], [OwnerName], [OwnerPhone], [OwnerEmail], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId]) VALUES (5, NULL, N'Beacon Homes LLC', N'120', N'Stoneleigh Place ave. 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', N'6', N'rrr', N'22222', N'asdfasf', 3, 1, 1, 1, 3, 1, 1, 42)
SET IDENTITY_INSERT [dbo].[Property2] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomsCounts] ON 

INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (1, N'1')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (2, N'2')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (3, N'3')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (4, N'4')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (5, N'5')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (6, N'6')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (7, N'7')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (8, N'8')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (9, N'9')
INSERT [dbo].[RoomsCounts] ([Id], [CountName]) VALUES (11, N'9+')
SET IDENTITY_INSERT [dbo].[RoomsCounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Propertiesses] ON 

INSERT [dbo].[Propertiesses] ([Id], [MyProfileForAgentsId], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [Price], [AddedDate], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [RoomsCountId], [BuildingAgeId], [AirCondition], [Bedding], [Heating], [Internet], [Microwave], [Smoking], [Terrace], [Balcony], [Dryer], [Parking], [Beach], [Supermarket]) VALUES (12, 42, N'Beacon Homes LLC', N'120', N'Stoneleigh Place ave. 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', N'6', CAST(1.00 AS Decimal(18, 2)), CAST(N'2018-12-12T00:00:00.0000000' AS DateTime2), 2, 3, 1, 1, 1, 3, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Propertiesses] OFF
GO
SET IDENTITY_INSERT [dbo].[Properties] ON 

INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (4, N'0cca66c5-8186-4399-be3a-c11f491d3547-01.07.2021.16.32.00-p-1.jpg', N'Beacon Homes LLC', N'120', N'Stoneleigh Place ave. 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 6, 1, 1, 1, 1, 1, 1, 38, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, CAST(N'2020-03-04T00:00:00.0000000' AS DateTime2), CAST(120.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (5, N'd636b2e4-51de-436c-ab76-b24eac3ae1a5-01.07.2021.10.41.59-p-2.jpg', N'Bluebell Real Estate', N'125', N'Nobel pr', N'Azerbaijan', N'AZ1022', N'lorem ipsum dolot sir', 3, 2, 4, 2, 3, 3, 4, 42, 5, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, CAST(N'2021-04-06T00:00:00.0000000' AS DateTime2), CAST(30000.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (6, N'cef18867-ccb0-46ef-8364-934fe3811507-01.07.2021.15.45.47-p-4.jpg', N'Banyon Tree Realty', N'180', N'Sarabski 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 1, 2, 1, 1, 2, 3, 1, 38, 3, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, CAST(N'2021-05-09T00:00:00.0000000' AS DateTime2), CAST(25000.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (8, N'f568afa9-85e1-40ee-acaf-123e24aacedf-01.07.2021.08.49.12-p-8.jpg', N'Blue Reef Properties', N'75', N'Bul-bul pr. 79', N'Azerbaijan', N'AZ1022', N'lorem ipsum dolot sir', 4, 1, 3, 3, 1, 1, 3, 42, 3, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, CAST(N'2021-04-06T00:00:00.0000000' AS DateTime2), CAST(70.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (9, N'3baba31c-a6cd-46aa-8b6c-e0ce3ea6ddc3-01.07.2021.15.47.29-p-7.jpg', N'Clock Residence', N'110', N'Broadway Terrace', N'Azerbaijan', N'AZ1022', N'This list contains only street names in Manhattan. See separate entries for Bronx, Brooklyn, Queens and Staten Island
', 1, 1, 1, 2, 3, 2, 1, 38, 3, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, CAST(N'2021-06-25T19:02:10.6712204' AS DateTime2), CAST(90.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (117, N'a709fbfd-6c0a-4d7f-90d0-31a507e388b6-01.07.2021.08.49.31-p-17.jpg', N'BB Towers', N'90', N'Merdanov Qar', N'Azerbaijan', N'AZ5020', N'lorem ipsum dolot sir', 3, 3, 2, 2, 3, 1, 4, 42, 8, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-06-29T11:47:30.1369122' AS DateTime2), CAST(700.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (133, N'6b66d44f-cdb6-49dc-928e-798ad4d4b72c-13.07.2021.21.27.40-p-17.jpg', N'Residence A', N'150', N'Pushkin 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 1, 3, 3, 1, 2, 1, 2, 38, 3, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-06-30T12:12:59.6394407' AS DateTime2), CAST(600.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (137, N'76990ede-911b-45e4-b100-7e9f17d839df-13.07.2021.21.27.59-p-12.jpg', N'Residence B', N'150', N'Pushkin 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 1, 3, 3, 1, 2, 1, 2, 38, 3, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-06-30T12:12:59.6394407' AS DateTime2), CAST(600.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (138, N'bd3843ff-c9fa-4d00-880b-2f9eb2b873d5-13.07.2021.21.28.21-p-11.jpg', N'Residence C', N'150', N'Pushkin 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 1, 3, 3, 1, 2, 1, 2, 38, 3, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-06-30T12:12:59.6394407' AS DateTime2), CAST(600.00 AS Decimal(18, 2)), N'https://www.youtube.com/watch?v=t-iPoKxjR94')
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (139, N'0f6ff6a7-1f79-477f-acfc-8e3252e1a095-17.07.2021.18.01.55-p-6.jpg', N'Residence D', N'150', N'Pushkin 122', N'Azerbaijan', N'AZ1000', N'lorem ipsum dolot sir', 1, 3, 3, 1, 2, 1, 2, 38, 3, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-06-30T12:12:59.6394407' AS DateTime2), CAST(600.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Properties] ([Id], [MainImage], [Name], [AreaKv], [Adress], [State], [ZipCode], [Description], [CityOfPropertyId], [PropertyStatusId], [PropertyTypeId], [BathroomCountId], [BedroomsCountId], [GarageCountId], [BuildingAgeId], [MyProfileForAgentsId], [RoomsCountId], [AirCondition], [Balcony], [Beach], [Bedding], [Dryer], [Heating], [Internet], [Microwave], [Parking], [Smoking], [Supermarket], [Terrace], [AddedDate], [Price], [VideoLink]) VALUES (170, N'fffce576-1114-4f7d-818c-ceb2d24ef4a4-14.08.2021.13.17.27-c-5.png', N'dd', N'22', N'Broadway Terrace', N'Azerbaijan', N'AZ1022', NULL, 1, 1, 2, 1, 3, 2, 1, 54, 4, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, CAST(N'2021-08-14T13:17:27.2111834' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Properties] OFF
GO
SET IDENTITY_INSERT [dbo].[AmenetiesProperties] ON 

INSERT [dbo].[AmenetiesProperties] ([Id], [Title], [PropertyId], [Property2Id], [PropertiessId]) VALUES (2, N'Forest', 4, NULL, NULL)
INSERT [dbo].[AmenetiesProperties] ([Id], [Title], [PropertyId], [Property2Id], [PropertiessId]) VALUES (4, N'Summer Playground', 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AmenetiesProperties] OFF
GO
SET IDENTITY_INSERT [dbo].[OtherFeatures] ON 

INSERT [dbo].[OtherFeatures] ([Id], [PropertyId], [Property2Id], [PropertiessId], [Name], [Desc]) VALUES (14, 4, NULL, NULL, N'Boiler', N'yes')
SET IDENTITY_INSERT [dbo].[OtherFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyImages] ON 

INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (49, N'4215b9ed-cff5-449c-9fe9-57fa2ca2a3bd-01.07.2021.11.08.57-p-2.jpg', 5, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (50, N'737c7d20-696b-417a-979b-4348a71080cd-01.07.2021.11.09.07-p-3.jpg', 5, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (51, N'062ca354-8c40-4408-94ae-549ea12d2107-01.07.2021.11.09.18-p-4.jpg', 8, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (52, N'3877c3b0-efb2-4013-931b-a8bd1737baee-01.07.2021.11.09.30-p-10.jpg', 8, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (53, N'addf56a8-4c06-4a47-a701-e5ff0604a1c1-01.07.2021.11.09.47-p-25.jpg', 117, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (54, N'fff718c2-588f-4fb3-b937-b34faa59b04a-01.07.2021.15.44.51-p-1.jpg', 4, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (55, N'df0d90cf-ab4b-45b6-b1fe-74196be17755-01.07.2021.15.45.14-p-2.jpg', 4, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (56, N'822632d0-089d-4cec-a33e-2112723b647c-01.07.2021.15.45.27-p-3.jpg', 4, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (57, N'419195ed-b49c-459c-915a-dbc4dea42e24-01.07.2021.15.46.38-p-4.jpg', 6, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (58, N'9735ead3-d6a5-4fb0-bb05-12dbfdda4095-01.07.2021.15.46.52-p-5.jpg', 6, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (59, N'49e0310c-50b7-445b-962c-02358b684e52-01.07.2021.15.47.04-p-6.jpg', 6, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (63, N'864d3d65-9a5f-4ef3-996a-d2c52fd6ea34-01.07.2021.15.49.15-p-7.jpg', 9, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (64, N'2f6fc432-8795-4565-8acc-cdb0c9e41e12-01.07.2021.15.49.26-p-8.jpg', 9, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (65, N'98d908aa-2326-4626-9115-afc3b052f119-01.07.2021.15.49.39-p-9.jpg', 9, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (66, N'ac77be66-e38e-471b-b30c-39aeb9237797-01.07.2021.15.50.38-p-10.jpg', 133, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (67, N'7e844802-35b8-4bcd-8c2f-ff6a9047dce4-01.07.2021.15.50.53-p-11.jpg', 133, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (68, N'02bfbc8f-f06a-4e00-9add-ea0bc5e61fa7-01.07.2021.15.51.06-p-12.jpg', 133, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (78, N'6c607129-056a-4dfe-9459-04adeeb54110-13.07.2021.21.34.51-p-12.jpg', 137, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (79, N'4993e58c-4cfe-45c5-a125-8b9827b86478-13.07.2021.21.35.04-p-6.jpg', 137, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (80, N'02b88ff9-8d83-4dac-bc6b-150b77b55c39-13.07.2021.21.35.22-p-8.jpg', 137, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (81, N'0c7ad513-9278-4e46-a6f8-c7863f1addf4-13.07.2021.21.35.52-p-11.jpg', 138, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (82, N'd2ebb545-0346-4c63-93dc-e592f9004c4f-13.07.2021.21.36.05-p-9.jpg', 138, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (83, N'c16915d5-aa6d-45db-a242-1e8be3e10b4f-13.07.2021.21.36.29-p-2.jpg', 138, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (84, N'b6ed6e56-1009-4ecb-96cb-3a88b4ae3c5e-13.07.2021.21.37.05-p-5.jpg', 139, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (85, N'e25b0783-4250-4342-bc66-61539810bca1-13.07.2021.21.37.24-p-2.jpg', 139, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (86, N'74f6c1b4-5d74-4f32-9433-e1f2cff36c01-13.07.2021.21.37.59-pl-6.jpg', 139, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (87, N'6e278bc8-dc66-4e97-9bfd-ea78167155c6-13.07.2021.21.40.36-p-10.jpg', 5, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (88, N'1c81a0d4-4a09-433e-aec7-d84569ef7129-13.07.2021.21.41.05-p-9.jpg', 8, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (89, N'0e6e65c7-29c1-4e2b-b706-b7fdd761aff1-13.07.2021.21.41.24-p-1.jpg', 117, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (90, N'c4cedbce-e7bf-40a4-b73f-72bf30dfad25-13.07.2021.21.41.40-p-8.jpg', 117, NULL, NULL)
INSERT [dbo].[PropertyImages] ([Id], [Image], [PropertyId], [Property2Id], [PropertiessId]) VALUES (120, N'4e904497-db11-4d69-8996-d802a0def22b-14.08.2021.13.17.27-c-5.png', 170, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PropertyImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [ReviewId], [ParentReviewId], [CustomerId], [PropertyId], [Content], [Rating], [AddedDate], [Property2Id], [PropertiessId], [MyProfileForAgentsId]) VALUES (3, NULL, NULL, NULL, 4, N'Perfect quality!!!', 0, CAST(N'2021-07-05T14:48:29.8630547' AS DateTime2), NULL, NULL, 38)
INSERT [dbo].[Reviews] ([Id], [ReviewId], [ParentReviewId], [CustomerId], [PropertyId], [Content], [Rating], [AddedDate], [Property2Id], [PropertiessId], [MyProfileForAgentsId]) VALUES (5, NULL, NULL, NULL, 4, N'Location is the best. 10/10', 0, CAST(N'2021-07-05T14:50:02.5674766' AS DateTime2), NULL, NULL, 43)
INSERT [dbo].[Reviews] ([Id], [ReviewId], [ParentReviewId], [CustomerId], [PropertyId], [Content], [Rating], [AddedDate], [Property2Id], [PropertiessId], [MyProfileForAgentsId]) VALUES (8, NULL, NULL, NULL, 4, N'Hello my agent', 0, CAST(N'2021-07-19T17:39:37.6780920' AS DateTime2), NULL, NULL, 38)
INSERT [dbo].[Reviews] ([Id], [ReviewId], [ParentReviewId], [CustomerId], [PropertyId], [Content], [Rating], [AddedDate], [Property2Id], [PropertiessId], [MyProfileForAgentsId]) VALUES (10, NULL, NULL, NULL, 8, N'nice flat', 0, CAST(N'2021-07-20T07:57:17.3142345' AS DateTime2), NULL, NULL, 43)
INSERT [dbo].[Reviews] ([Id], [ReviewId], [ParentReviewId], [CustomerId], [PropertyId], [Content], [Rating], [AddedDate], [Property2Id], [PropertiessId], [MyProfileForAgentsId]) VALUES (11, NULL, NULL, NULL, 4, N'salam', 0, CAST(N'2021-08-14T12:57:30.9082572' AS DateTime2), NULL, NULL, 43)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialsMyProfiles] ON 

INSERT [dbo].[SocialsMyProfiles] ([Id], [Icon]) VALUES (1, N'lni-facebook')
INSERT [dbo].[SocialsMyProfiles] ([Id], [Icon]) VALUES (2, N'lni-twitter')
INSERT [dbo].[SocialsMyProfiles] ([Id], [Icon]) VALUES (3, N'lni-instagram')
INSERT [dbo].[SocialsMyProfiles] ([Id], [Icon]) VALUES (4, N'lni-linkedin')
SET IDENTITY_INSERT [dbo].[SocialsMyProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialToMyProfs] ON 

INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (15, 38, N'https://www.facebook.com/ngolo', 1)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (16, 38, N'https://www.twitter.com/ngolo', 2)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (17, 38, N'https://www.instagram.com/ngolo', 3)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (18, 38, N'https://www.linkedin.com/ngolo', 4)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (20, 42, N'https://www.facebook.com/roof', 1)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (21, 42, N'https://www.twitter.com/roof', 2)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (22, 42, N'https://www.instagram.com/roof', 3)
INSERT [dbo].[SocialToMyProfs] ([Id], [MyProfileForAgentsId], [Link], [SocialsMyProfileId]) VALUES (23, 42, N'https://www.linkedin.com/roof', 4)
SET IDENTITY_INSERT [dbo].[SocialToMyProfs] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodsArounds] ON 

INSERT [dbo].[FoodsArounds] ([Id], [RestaurantName], [Miles], [PropertyId]) VALUES (1, N'KFC', CAST(2.22 AS Decimal(18, 2)), 4)
INSERT [dbo].[FoodsArounds] ([Id], [RestaurantName], [Miles], [PropertyId]) VALUES (2, N'Pizza Hat', CAST(5.52 AS Decimal(18, 2)), 4)
INSERT [dbo].[FoodsArounds] ([Id], [RestaurantName], [Miles], [PropertyId]) VALUES (3, N'Burger King', CAST(9.55 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[FoodsArounds] OFF
GO
SET IDENTITY_INSERT [dbo].[SchoolsArounds] ON 

INSERT [dbo].[SchoolsArounds] ([Id], [SchoolName], [Miles], [PropertyId]) VALUES (1, N'Oxford', CAST(5.22 AS Decimal(18, 2)), 4)
INSERT [dbo].[SchoolsArounds] ([Id], [SchoolName], [Miles], [PropertyId]) VALUES (4, N'Xezer', CAST(3.66 AS Decimal(18, 2)), 4)
INSERT [dbo].[SchoolsArounds] ([Id], [SchoolName], [Miles], [PropertyId]) VALUES (5, N'ADA University', CAST(5.45 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[SchoolsArounds] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribeds] ON 

INSERT [dbo].[Subscribeds] ([Id], [Email], [Phone], [Message], [AddedDate], [MyProfileForAgentsId]) VALUES (45, N'rufaeetzz@dsasedu.az', N'44455333', N'alaaaaaa', CAST(N'2021-06-24T10:00:03.6023106' AS DateTime2), 42)
SET IDENTITY_INSERT [dbo].[Subscribeds] OFF
GO
SET IDENTITY_INSERT [dbo].[Aboutcs] ON 

INSERT [dbo].[Aboutcs] ([Id], [Image], [Title], [Desc]) VALUES (6, N'3d332f4a-6353-4458-b4f4-2993b4326e58-14.07.2021.21.55.27-sb.png', N'Our Story', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

')
SET IDENTITY_INSERT [dbo].[Aboutcs] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactAdresses] ON 

INSERT [dbo].[ContactAdresses] ([Id], [Icon], [Title], [Adress]) VALUES (1, NULL, NULL, N'Azerbaijan, Baku, Nobel pr. 147')
INSERT [dbo].[ContactAdresses] ([Id], [Icon], [Title], [Adress]) VALUES (2, NULL, NULL, N'Azerbaijan, Baku, Narimanov st. 122')
SET IDENTITY_INSERT [dbo].[ContactAdresses] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactEmails] ON 

INSERT [dbo].[ContactEmails] ([Id], [Icon], [Title], [Email]) VALUES (1, NULL, N'rrrrrrrr', N'resido@gmail.com')
INSERT [dbo].[ContactEmails] ([Id], [Icon], [Title], [Email]) VALUES (2, NULL, NULL, N'resido@outlook.com')
SET IDENTITY_INSERT [dbo].[ContactEmails] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactPhones] ON 

INSERT [dbo].[ContactPhones] ([Id], [Icon], [Title], [Phone]) VALUES (1, NULL, NULL, N'+994517778997')
INSERT [dbo].[ContactPhones] ([Id], [Icon], [Title], [Phone]) VALUES (2, NULL, NULL, N'+0125678995')
INSERT [dbo].[ContactPhones] ([Id], [Icon], [Title], [Phone]) VALUES (8, NULL, NULL, N'+380 (67)-995-33-65')
SET IDENTITY_INSERT [dbo].[ContactPhones] OFF
GO
SET IDENTITY_INSERT [dbo].[HowItWorks] ON 

INSERT [dbo].[HowItWorks] ([Id], [Icon], [Title], [Desc]) VALUES (1, N'ti-receipt text-success', N'Evaluate Property', N'Blog posts written by your target group for your target group. Our network consists of qualified authors and a representative consumer cross section.')
INSERT [dbo].[HowItWorks] ([Id], [Icon], [Title], [Desc]) VALUES (2, N'ti-user text-warning', N'Meet Your Agent
', N'When blogging, it pays dividends to lay out the structure of your piece before you begin writing. The structure is the skeleton of your text and preparing.')
INSERT [dbo].[HowItWorks] ([Id], [Icon], [Title], [Desc]) VALUES (3, N'ti-shield text-blue', N'Close The Deal
', N'There are many variations of passages of Lorem Ipsum available, but the majority have Ipsum available. Lorem ipsum dolot sir

')
SET IDENTITY_INSERT [dbo].[HowItWorks] OFF
GO
SET IDENTITY_INSERT [dbo].[OurMissionInAbouts] ON 

INSERT [dbo].[OurMissionInAbouts] ([Id], [Icon], [Title], [Desc]) VALUES (1, N'ti-lock theme-cl', N'Fully Secure & 24x7 Dedicated Support', N'If you are an individual client, or just a business startup looking for good backlinks for your website.')
INSERT [dbo].[OurMissionInAbouts] ([Id], [Icon], [Title], [Desc]) VALUES (2, N'ti-twitter theme-cl', N'Manage Your Social & Busness Account Carefully', N'If you are an individual client, or just a business startup looking for good backlinks for your website.')
INSERT [dbo].[OurMissionInAbouts] ([Id], [Icon], [Title], [Desc]) VALUES (6, N'ti-layers theme-cl', N'Manage Your Social & Busness Account Carefully', N'If you are an individual client, or just a business startup looking for good backlinks for your website.

')
SET IDENTITY_INSERT [dbo].[OurMissionInAbouts] OFF
GO
SET IDENTITY_INSERT [dbo].[OurMissionMainImages] ON 

INSERT [dbo].[OurMissionMainImages] ([Id], [Image]) VALUES (3, N'b948f21e-fbbc-45c5-a6bb-16a05e30bd7a-15.07.2021.16.47.50-vec-2.png')
SET IDENTITY_INSERT [dbo].[OurMissionMainImages] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteSocials] ON 

INSERT [dbo].[SiteSocials] ([Id], [Icon], [Link]) VALUES (1, N'ti-facebook', N'facebook.com/resido')
INSERT [dbo].[SiteSocials] ([Id], [Icon], [Link]) VALUES (2, N'ti-twitter', N'twitter.com/resido')
INSERT [dbo].[SiteSocials] ([Id], [Icon], [Link]) VALUES (3, N'ti-instagram', N'instagram.com/resido')
INSERT [dbo].[SiteSocials] ([Id], [Icon], [Link]) VALUES (4, N'ti-linkedin', N'linkedin.com/resido')
SET IDENTITY_INSERT [dbo].[SiteSocials] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribes] ON 

INSERT [dbo].[Subscribes] ([Id], [Email], [Phone], [Message], [AddedDate]) VALUES (3, N'rufatzz@dsasedu.az', N'0555565212', N'Please call me', CAST(N'2021-06-23T13:56:50.7203117' AS DateTime2))
INSERT [dbo].[Subscribes] ([Id], [Email], [Phone], [Message], [AddedDate]) VALUES (21, N'luissuarez@uruguay.az', N'0777899889', N'Hi again. Pls recall', CAST(N'2021-06-23T14:54:10.7840412' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Subscribes] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAdmins] ON 

INSERT [dbo].[UserAdmins] ([Id], [Name], [Email], [Password]) VALUES (1, N'Rufat', N'rufatzulfigarov@gmail.com', N'$2a$11$HIX3Bj/KYacXcxI.1OAZXumAKi2WSbZvtrPaVZ0EAPICuJ7IrPh8q')
SET IDENTITY_INSERT [dbo].[UserAdmins] OFF
GO
