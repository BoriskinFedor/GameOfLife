   M S B A M L   `   `   `  ����E  AGameOfLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GameOfLife
GameOfLife  5   	       GameOfLife.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GameOfLife     5   	     � Title$  
MainWindow��5   	    � 
ResizeMode$ NoResize=�6    � WindowState$ 	Maximized=�62   .��5	      ]� .+�5
   
   o� $	��Top=�6   
�������.@�5      m� $
��Game��6   $��14(�6%   .@�5      m� -   5        $	��New��5      6(   m� 5      -   5        $��Clear��5      6*   �� 5      m� 5      -   5        $
��Exit��5      6)   5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Bottom=�6.   
�������.+�5      �� 6   �� 5      -   5        $
��Stop��5      $��14(�6$   $��50,0,0,5q�6L   $��	25,0,25,0q�6^   �� 5      -   5        $	��Run��5      $��14(�6#   $��20,0,0,5q�6J   $��	25,0,25,0q�6\   �� 5      -   5        $��Next Generation��5      $��14(�6/   $��25,0,0,5q�6\   $��	10,0,10,0q�6n   �� 5      -   5        $��14(�5   2   $��20,0,0,5q�6_   .��6q   Display next state6�   �� 5      -   5         ��Name$ Text_GenCounter��5      $��14(�61   $��20,0,0,5q�6?   �� 6R   $�Поколение:��6V   6k   5      � 5   
   -	   5        $��Bitmap��5      $��2,2,0,0q�6   .+�5      �� -
   5        $��bitmapImage��5      6{   5      5      5      