   M S B A M L   `   `   `  ����D  @SudoWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SudoWorld	SudoWorld  5   	       SudoWorld.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SudoWorld     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5	   	   $	��600��5
   	   $	��400��5   	    � Title$ 
MainWindow��5   	      MaterialDesignPaper#���   5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 0q�6      CornerRadius$ 35��5         CaptionHeight$ 0Q�5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5        	  Name$	 header��5   #   $��5q�63   .  (MaterialDesignThemes.Wpf.ElevationAssist
   	Elevation$	
 Dp4=�5   #   $
}�True��5    #      CornerRadius$ 0��5!   #      Mode$ PrimaryDark=�5"   #   .��5$      �  � ColumnDefinitions 5%      �� 5&      $��* �6+   �� 5'      $
��auto �6+   .+�5)      ��  �� Orientation$ 
Horizontal=�6!   .+�5*      ��   	LogoWhite#��[ 6    $��25��6D   $��25��6P   $��5,0,0,0q�6[   �� 5+      $��10,0,0,0q�6$   $��Center=�5,   $   $��	SudoWorld��5-   $   5.      �� 5/      $��1��6!   $��0��61   $ 
Horizontal=�6>   $��Center=�6W   $��Right=�6r   .+�50      �� -   5         ��Name$ minimizeBtn��50      $��30��62   $��30��51        MaterialDesignIconButton#���  52      
�������.��54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   55      �� 56      -   5        $ closeBtn��56      $��30��6/   $��30��57      #���  58      
�������.��5:        $ 	CloseBold=�62   $��20��5;   2   $��20��5<   2   5=      5?      5@      5B      �� 5C   
   $��1��5D      $��Stretch=�5E      $��Stretch=�5F       =� ErrorTemplate 5C      Z� ��5G      �� *Navigation.CurrentView+5H      5I      