   M S B A M L   `   `   `  ????K  GPictureMergerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PictureMergerWPF.ViewModelsPictureMergerWPF.ViewModels  5   	   3clr-namespace:PictureMergerWPFPictureMergerWPF  5   	   !    PictureMergerWPF.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8vm)clr-namespace:PictureMergerWPF.ViewModels     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *localclr-namespace:PictureMergerWPF  5   	   $	??450??5
   !   $	??800??6.     ? 
ResizeMode$  CanResizeWithGrip=?5   	      MaterialDesignPaper#???   5   	     MaterialDesignFont#???  5   	    ? Title 5
   	   ?? *Title+ ? DataContext 5      5  /PictureMergerWPF.ViewModels.MainWindowViewModel  5   
   .??5      ? .+?5   
   ?? $??0??6   .@?5      ?? $??
Файли??6   .??5      ?  ? RowDefinitions 5      ?? 5      $??1* ?6(   ?? 5      $
??0.2* ?6(   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ FilesList_DataGrid??5      $??0??6;      AutoGenerateColumns$ False??6H   $
??True??5      "   VerticalScrollBarVisibility$ Visible=?5      $   HorizontalScrollBarVisibility$ Visible=?5       ??5   d   ?? *SelectedPictures+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly$
	 True??61   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.5* 6C      Header$ Позиція??6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6b   ?? *Id+  5#      $
	 True??61   $
 1* 6C   $ Назва файлу??6N    6d   ?? *Name+  5$      $
	 True??61   $
 1* 6C   $ Шлях до файлу??6N    6f   ?? *Path+4  .System.Windows.Controls.DataGridTemplateColumn  5%         CellTemplate 5&   "   ?? 5'   &   .R?5(   *   ?? $	??↑??61   ??6=   ??  ?? Path$/ )DataContext.ChangeToUpFilePositionCommand? ?? RelativeSource ??  ?? AncestorType"  ??5)   z   ?? 5+   '   5-        5.       5/   "   ?? 50   &   .R?51   *   ?? $	??↓??61   ??6=   ?? $1 +DataContext.ChangeToDownFilePositionCommand? ?? "  ??52   z   ?? 53   '   55      57      ?? 59      $??1??6!    ?? Orientation$ 
Horizontal=?6.   $??Center=?6G   $??Bottom=?6d   .+?5:      ??  ! MaterialDesignPaperDarkButton#??[ 6!   $-??'Завантажити картинки??6Y   $
??Left=?6x   $??10q?6?   $	??Top=?5;      ??6-   ?? *LoadFilesCommand+?? 5@      #??[ 6!   $??Зберегти??6X   $
??Left=?6k   $??10q?6?   $	??Top=?5A      ??6-   ?? *SaveMergedPictureCommand+5B      5D      5E      ?? 5F      $??Preview??6   .??5G      ?? 5I      5J      5K      5l      5m      