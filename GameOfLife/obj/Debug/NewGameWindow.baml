   M S B A M L   `   `   `  ����E  AGameOfLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GameOfLife
GameOfLife  5   	       GameOfLife.SubWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $localclr-namespace:GameOfLife  5   	     � Title$  NewGameWindow��5	   	   $	��250��6   $	��250��6,    � 
ResizeMode$ NoResize=�68   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   6,   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6$   $��Center=�61   $��Right=�6L   	Cell size6s   �� 5   
   -   5        $��SliderCellsize��5      $��1��6'   $��0��67    � Minimum$ 2Q�6D    � Maximum$ 20Q�6P   $��Center=�6]   $��Center=�6x   $	��100��6�   �� 5   
   $��0��6   $��1��6$   $��Center=�61   $��Right=�6L   Auto Density6v   �� 5   
   -   5        $��SliderDensity��5      $��1��6&   $��1��66   $ 2Q�6C   $ 50Q�6O   $��Center=�6\   $��Center=�6w   $	��100��6�   �� 5   
   -   5        $��0��5   [   $��2��6k   $��2��6x   $��Center=�6�   $��Center=�6�   .��6�   Random first generation6�   �� 5   
   -   5        $��0��5   [   $��3��6k   $��2��6x   $��46,10,110,19q�6�   .��6�   Looped field6�   �� 5    
   -   5        $��0��5       $��4��6!   $��2��6.   $��Create��6B   $��25��6S   $��75��6_   6j   5!      5"      