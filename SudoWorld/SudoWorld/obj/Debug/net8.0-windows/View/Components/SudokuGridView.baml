   M S B A M L   `   `   `  ����D  @SudoWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SudoWorld.View.ComponentsSudoWorld.View.Components  5      .    (SudoWorld.View.Components.SudokuGridView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SudoWorld.View.Components     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6    � ColumnDefinitions 5   
   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   .+�5      �� $��0��6   $��7��5       %  !MaterialDesign.Brush.Primary.Dark#���   5      �� 5   
   $��2��6   $��7��5       #���   5!      �� 5"   
   $��4��6   $��7��5#      #���   5$      �� 5%   
   $��6��6   $��7��5&      #���   5'      �� 5(   
   $��0��6   $��7��5)      #���   5*      �� 5+   
   $��2��6   $��7��5,      #���   5-      �� 5.   
   $��4��6   $��7��5/      #���   50      �� 51   
   $��6��6   $��7��52      #���   53      .   (SudoWorld.View.Components.SudokuCellView  54   
   $��Stretch=�6O   $��1��6m   $��1��6}   $��Stretch=�55       � DataContext 54      �� *SudokuCellViewModels[0]+55        56   
   $��Stretch=�6O   $��Stretch=�57      $��3��58      $��1��59       56      �� *SudokuCellViewModels[1]+59        5:   
   $��Stretch=�6O   $��Stretch=�5;      $��5��5<      $��1��5=       5:      �� *SudokuCellViewModels[2]+5=        5>   
   $��Stretch=�6O   $��Stretch=�5?      $��1��5@      $��3��5A       5>      �� *SudokuCellViewModels[3]+5A        5B   
   $��Stretch=�6O   $��Stretch=�5C      $��3��5D      $��3��5E       5B      �� *SudokuCellViewModels[4]+5E        5F   
   $��Stretch=�6O   $��Stretch=�5G      $��5��5H      $��3��5I       5F      �� *SudokuCellViewModels[5]+5I        5J   
   $��Stretch=�6O   $��Stretch=�5K      $��1��5L      $��5��5M       5J      �� *SudokuCellViewModels[6]+5M        5N   
   $��Stretch=�6P   $��Stretch=�5O      $��3��5P      $��5��5Q       5N       �� *SudokuCellViewModels[7]+5Q        5R   
   $��Stretch=�6P   $��Stretch=�5S      $��5��5T      $��5��5U       5R       �� *SudokuCellViewModels[8]+5U      5X      5Y      