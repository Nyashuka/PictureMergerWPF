   M S B A M L   `   `   `  ???? K  GPictureMergerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PictureMergerWPF.ViewModelsPictureMergerWPF.ViewModels  3clr-namespace:PictureMergerWPFPictureMergerWPF  !    PictureMergerWPF.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8vm)clr-namespace:PictureMergerWPF.ViewModels     _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  *localclr-namespace:PictureMergerWPF  $	??450??$	??800??  ? 
ResizeMode$  CanResizeWithGrip=?   MaterialDesignPaper#???     MaterialDesignFont#???   ? Title ?? *Title+ ? DataContext 5  /PictureMergerWPF.ViewModels.MainWindowViewModel  .??? .+??? $??0??.@??? $??
Файли??.???  ? RowDefinitions ?? $??1* ??? $
??0.2* ?.+?&   System.Windows.Controls.DataGrid  -     Name$ FilesList_DataGrid??$??0??   AutoGenerateColumns$ False??$
??True??"   VerticalScrollBarVisibility$ Visible=?$   HorizontalScrollBarVisibility$ Visible=????? *SelectedPictures+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly$
	 True??
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.5*    Header$ Порядок??1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *Id+  $
	 True??$
 1* $ Назва файлу?? ?? *Name+  $
	 True??$
 1* $ Шлях до файлу?? ?? *Path+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate ?? .R??? $	??↑??????  ?? Path$/ )DataContext.ChangeToUpFilePositionCommand? ?? RelativeSource ??  ?? AncestorType"  ????    ?? .R??? $	??↓?????? $1 +DataContext.ChangeToDownFilePositionCommand? ?? "  ???? ?? $??1?? ?? Orientation$ 
Horizontal=?$??Center=?$??Bottom=?.+???  ! MaterialDesignPaperDarkButton#??[ $-??'Завантажити картинки??$
??Left=?$??10q?$	??Top=????? *LoadFilesCommand+?? #??[ $??Зберегти??$
??Left=?$??10q?$	??Top=????? *SaveMergedPictureCommand+?? $??Preview??.???? 