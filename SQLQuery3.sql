USE [MediStock]
GO
INSERT [dbo].[Stock] ([Id], [name], [price], [company], [exp_date], [med_per_packet], [available], [storage_row], [storage_col]) VALUES (1, N'Peracitamol                   ', 30, N'Xmedi                         ', CAST(N'2025-12-12' AS Date), 30, 10, 4, 5)
GO
INSERT [dbo].[Stock] ([Id], [name], [price], [company], [exp_date], [med_per_packet], [available], [storage_row], [storage_col]) VALUES (2, N'Senitizer                     ', 50, N'Dettol                        ', CAST(N'2026-12-30' AS Date), NULL, 20, 6, 7)
GO
INSERT [dbo].[Stock] ([Id], [name], [price], [company], [exp_date], [med_per_packet], [available], [storage_row], [storage_col]) VALUES (3, N'Metacin                     ', 40, N'CoreMedi                        ', CAST(N'2024-4-1' AS Date), 30, 4, 6, 7)
GO
INSERT [dbo].[Stock] ([Id], [name], [price], [company], [exp_date], [med_per_packet], [available], [storage_row], [storage_col]) VALUES (4, N'Telma                     ', 100, N'Coxin                        ', CAST(N'2024-2-1' AS Date), 40, 2, 6, 7)
GO