   M S B A M L   `   `   `  ���� G  CSearchEngine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SearchEngineSearchEngine      SearchEngine.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:SearchEngine       � Title$  Company Search��$	��450��$	��800�� � 
ResizeMode$ NoResize=�����  �� Color$ #FFEC9E��.��� -    �Name$ hover�� � ColumnDefinitions �� $��10 ��� $	��150 ��� $��* ��� $	��150 ��� $��10 � � RowDefinitions �� $��10 ��� $��75 ��� $��70 ��� $��* ��� $��10 �.+��� $��1��$��5�����#ED9455�� $��0��$��5�����#ED9455�� -   $��DropBox��$��1��$��Center=�$��0,12,0,0q�$��2��$	��Top=�$	��120��$��37�� �� SelectedIndex$ 0��
���   ����#ED9455�� $��2q� �� CornerRadius$ 1��
�������$��0,10,0,0q�$��2��$��2��$��Stretch=�$	��Top=�._��� -   $��	SearchBox�� �� TextWrapping$
 Wrap=�$��	Search...��
���OO/�$��25(�$��Stretch=�$��Center=�$
��Auto��$��37�����	#FFFFB163���	#FFF87F07�� -   $��SearchButton��$��3��$��🔍 SEARCH��$��Center=�$��2��$	��Top=�$	��130��$��50��
���   �$
��Bold"�$��15(����	#00000000$��0,5,0,0q�	 � Cursor$
	 Hand������ 
 �� ImageSource$
 /pngegg.PNG�� j� Stretch$ Uniform=��� -   $��CompanyHeader��$��2��$��Stretch=�$��1��$
��Wrap=�$��Center=�$��39��$
��Auto��$��30(�$
��Bold"�
���   ����� *Text+ �� ElementName$ 	SearchBox���� -   $��UploadButton��$��3��$��       UPLOAD��$
��Left=�$��1��$��Center=�$	��125��$��50��$��15(�$
��Bold"�
���   �$��10,0,0,0q����	#00000000$
	 Hand������ $
 /pngegg.PNG���� -   $��SearchResultsListBox��$��3��$��	0,28,10,0q�$��1��$��1,1,1,1q����	#FFFFB163���	#FFF87F07���� .R���  �� Orientation$ Vertical=�.+��� $��20(����� *CompanyName+�� -   $��NoResultTextBlock��$y�	Collapsed=�$��1��$��3��$��0,34,0,0q�$��No result found���� $��1��$��Center=�$��70��$��0,5,0,0q�$��2��$	��Top=�$��70��$%��/image-removebg-preview (2).png���� $��3��$
��Left=�$��26��$��29,0,0,0q�$��1��$��Center=�$��32��$��/icons8-upload-64.png�� J� OpacityMask �� $
 /icons8-upload-64.png���� -	   $��ResultFound��$��1��$
��Left=�$��10,1,0,0q�$��3��$
��Wrap=�$��	RESULTS: ��$	��Top=�$��20(�$
��Bold"�$	��125���� $��2��$��Center=�$	��249��$��3�����	#FFED9455$��Center=�$	��460��$��5���� $��2��$
��Left=�$��	21,35,0,0q�$��3��$
��Wrap=�$��Company Name :��$	��Top=�$��23��$	��143��$��17(�$
��Bold"��� $��2��$
��Left=�$��	94,75,0,0q�$��3��$
��Wrap=�$��
  SEC # : ��$	��Top=�$��24��$��70��$��17(�$
��Bold"� J� RenderTransformOrigin$ 0.227,0.668&��� $��2��$
��Left=�$��
56,109,0,0q�$��3��$
��Wrap=�$��  Licensed # :��$	��Top=�$��24��$	��108��$��17(�$
��Bold"��� $��2��$
��Left=�$��
21,144,0,0q�$��3��$
��Wrap=�$��Date Registered :��$	��Top=�$��28��$	��143��$��17(�$
��Bold"��� $��2��$
��Left=�$��
310,75,0,0q�$��3��$
��Wrap=�$��Violations :��$	��Top=�$��24��$	��104��$��17(�$
��Bold"��� $��2��$
��Left=�$��
21,177,0,0q�$��3��$
��Wrap=�$��Tax Payer Name :��$	��Top=�$��28��$	��143��$��17(�$
��Bold"��� -
    ��Name$ CompanyName��$��2��$
��Left=�$��
166,30,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��278��$��35��$��17(�$
��Bold"�$��Italic$� �� 
IsReadOnly$
 True�����	#FFFFB163���	#FFF87F07�� -   $ SecNum��$��2��$��Center=�$��0,73,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��134��$��26��$��17(�$
��Bold"�$��Italic$�$
 True�����	#FFFFB163���	#FFF87F07�� -   $ LicenseNumber��$��2��$��Center=�$��	0,109,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��134��$��26��$��17(�$
��Bold"�$��Italic$�$
 True�����	#FFFFB163���	#FFF87F07�� -   $ DateRegistered��$��2��$��Center=�$��	0,144,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��134��$��26��$��17(�$
��Bold"�$��Italic$�$
 True�����	#FFFFB163���	#FFF87F07�� -   $ TaxPayerName��$��2��$��Center=�$��	0,177,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��134��$��26��$��17(�$
��Bold"�$��Italic$�$
 True�����	#FFFFB163���	#FFF87F07�� -   $ 
Violations��$��2��$
��Left=�$��310,109,0,0q�$��3��$
 Wrap=�$�� ��$	��Top=�$	��134��$��96��$��17(�$
��Bold"�$��Italic$�$
 True�����	#FFFFB163���	#FFF87F07�� -   $��FileUploads��$��3��$��3��$	��217��$	��Top=�$��	6,28,10,0q�$��1,1,1,1q����	#FFFFB163���	#FFF87F07���� .R��� $��15(����� �� -   $��uploads��$��3��$
��Left=�$��29,1,0,0q�$��3��$
��Wrap=�$��UPLOADS��$	��Top=�$��20(�$
��Bold"�