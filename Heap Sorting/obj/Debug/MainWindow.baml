   M S B A M L   `   `   `  ����G  CHeap Sorting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Heap_SortingHeap_Sorting  5   	       Heap_Sorting.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Heap_Sorting     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1350��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L   .��5	      �  � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      .+�5   
   �� -   5         ��Name$ 	textInput��5      $
��Left=�6%   $��20��6@   $��	10,10,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $��TextBox��6s   $	��Top=�6�   $	��632��6�   �� 5   
   -   5         ��Name$ 	buttonRun��5      $��Confirm��6$   $
��Left=�66   $��
647,10,0,0q�6Q   $	��Top=�6e   $��75��6}   $��20��6�   6�   �� 5   
   -   5        $ buttonClear��5      $��Clear��6&   $
��Left=�66   $��
807,10,0,0q�6Q   $	��Top=�6e   $��75��6}   $��20��6�   �� 5   
   -   5        $ 
buttonNext��5      $
��Next��6%   $
��Left=�64   $��
727,10,0,0q�6O   $	��Top=�6c   $��75��6{   $��20��6�   6�   �� 5   
   -   5         ��Name$ 
canvasTree��5      $��10q�6%   $��1��61   5      5      