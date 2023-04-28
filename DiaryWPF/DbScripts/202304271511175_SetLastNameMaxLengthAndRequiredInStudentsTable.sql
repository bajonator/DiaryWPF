﻿DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Students')
AND col_name(parent_object_id, parent_column_id) = 'LastName';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Students] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[Students] ALTER COLUMN [LastName] [nvarchar](100) NOT NULL
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202304271511175_SetLastNameMaxLengthAndRequiredInStudentsTable', N'DiaryWPF.ApplicationDBContext',  0x1F8B0800000000000400ED5ADB6EE336107D2FD07F10F4D41659CBCEBEB481BD8BAC9D2C826E2E88B3DBBE05B43476D84A942A52818DA25FD6877E527FA1435D29EA6AC771B6DB224060939C0B876786E4A1FFFEF3AFF1DBB5E71A8F1072EAB389391A0C4D0398ED3B94AD26662496AFBE37DFBEF9FAABF199E3AD8D4FD9B8D7721C4A323E311F84084E2C8BDB0FE0113EF0A81DFADC5F8A81ED7B16717CEB7838FCC11A8D2C401526EA328CF16DC404F520FE825FA73EB3211011712F7D075C9EB663CF3CD66A5C110F78406C9898334AC2CD4F37E7A671EA5282F6E7E02E4D8330E60B22D0BB938F1CE622F4D96A1E600371EF3601E0B8257139A45E9F14C3FB4E60782C27601582992A3BE2C2F7B654387A9D46C4D2C5778AAB99470C637686B1151B39EB386E13F37DE8478169E8964EA66E284715311D24E11FCC7018657C100B1E1959F7510E00C489FC3B32A6912BA210260C221112F7C8B889162EB57F84CD9DFF2BB0098B5C57750EDDC3BE520336DD847E00A1D8DCC23275F9C2310DAB2C67E982B9982293CCE78289D7C7A67185C6C9C2857CED95B9CF851FC27B60101201CE0D1102425CBA2B9F41C5B26647FECF2C21D030534CE392AC3F005B898789798CA9714ED7E0640DA9F18F8C625EA18C0823A8714E337A451EE92AF655333F1791034C70D3B805371EC01F6890E4C120EDBC4F97FC3CF4BD5BDF2DA4928EFB3B12AE40E024FCBADEB91F85B6E6D1D82A60D50AB654D52E704B45FF5380BB9033C6087681EE9C865C74206F34DC0FF434D31FC84B599EFA9E9740BDD1327EEC65B9DDD0A92DE82315147253EF7C4C0CC2B67639CEA06E60F44DF6348F77CFF42C97EB333DAB037DDDB9C546B6AA2F3D49DF7D9EFF8547E59E4AF1D1BA9F547D125DBB149F44F2FFDA53630B43035B02BA7ECFDA3A2F7435D1E217B0B757D3B5973E0DCF7A8A35C0BD0F9E4F39F76D1A7B52F6304DF3F2B4CE9863B4E67C5234956A81A513314C03442D5A9F98DF5542D5A4334FDA42675A79CA1A47A68EF76B3603170418B2C8CAE3F194709B38D555C29838E5164C11082546898B57048E494799A8E61365360D88DBE6B726D4330DA553B97ABD6706013069A96D0DFAD8CDB78CAAF1DC8616A9AEC08C2D0549ED00D360DE848626CC1770C84A6F7F8435ED0B9DB07D7990D5BB7E0094D5AF431FC34A0D3E00D092FA8632022520CCCE59815CC378F0EC9DEC8475DD4D016FF0E97ECDD3F39B0E21A97C0E42CD203C951445B55CA22A082C8B1737AA8A821C801D2A32F05714641D9ABC12B58A1FD9914E19537BE6D317B16B3BC87D56675C8142D706A068C9C2AEA75879723D26AE6FB5D599B755A93E754AF1BA7E45FA14A61E016C997CB6E7E73951B05C564273657498D5C0878D2F4910C8F3772199B618F3841C9BBE9A6FCF1F79890ECBE6353452EE6D6E09CF9264055AAFBCAB39105F526744900591A7B0A9E35586D5568086DCCA4C9692BCBA6A59C665C3E5E744243FEBD7264C11BE739C91BC68C693031DE155B99898242E096B0EE553DF8D3CD65CEB9BA5933BB62A9FB454358C2DCDF14A3DAF44A5B20B9663DC6B0572D0EFB4060DB9DB63151A259F671D14AA4555A234F7D7557027AAAAA2B5BFA6820B513515ADFD35A96487AA4B6DEFAF2D3FBDAAAA1A8FB42F86DDB4EAEF84DC7AD91EC06D127C1EDC26D774553E69E9AF413922AA6A5A4E8E2DBA8ABB7A4957D17C606C54F65F7D486E3DDF87B5FD769CEE7DDD8F5495CD3019621A18A447EAC88D70BEE102BC811C3098FFE64E5D1A1F7DB2019784D1257091304BE6F17074ACBD787D3EAF4F16E78EDBE709EAE0DC189521DD926452A96EF64842FB818495079E569D7B782BB9C0CBD87A62FE6EFCF14241EBA40CB78C6AE5FDA236B4F13BC2139F27F6A6587F7DC8147FE391F5B7AAB6DD5E1816747B6C6AAF0BB41D3B52E6C4B8F8F93E153B32AE432C2D27C61061B527083712EE5F1C8255167C97BA52E1C0FBAE5E2EB8C5FAF5E0CEBBE7B06F963AE5350E4A2157E88CDD68F19D48C2A65BE77351CF5F0EDBBCC55A3D135AB2BAB603C1FD94578BC351C8FF1ACEB84A2CF520839BB9E0E4243E319D858FAB9BD4BE0622B381276EA389EBB43772855B93C875DAF327F98332CCA5202B54590F3EB98E47FDBC38E42D1CADAD199D64F37E58E2EA6D14734FF96125263EA7AB4285FC992503BB9475F9980BB6F4B3FCD73CCA8668078A4B10C4C1943C0D055D125B60B70D9CC7D3FD44DC08879C790B702ED875248248E094C15BB8A55F1BC822D2663FA6C2CB3E8FAF83F8A17E1F534037294E01AED9BB88BA4EEEF779CD59A84185AC4EE92153AEA59087CDD526D754FD3D6193A2347C7951BD032F705119BF6673F208BBF8F691C30758117B93910ACD4ABA17A21CF6F18C9255483C9EEA28E4F12B62D8F1D66FFE018F061D765F2C0000 , N'6.4.4')

