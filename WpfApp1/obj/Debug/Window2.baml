   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Window2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Window2��5   	    � WindowStartupLocation$ CenterScreen=�6   ���#d8af29$	��403��5	   "   $	��802��6/    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   ���#0c1180.��5      � .+�5   
   �� $��10,10,10,10q�6   ���#5bff8060   �� 5   
   -   5         ��Name$ 
ExitButton��5      $��X��6%   $��764,0,0,372q�61    J� RenderTransformOrigin$ 
14.279,0.5&�5      
��� � �
���  ��5   "   �� 5   
   -   5         ��Name$ Welcome��5      $��40(�6%    �� TextAlignment$ Center=�63   $��Welcome ��6J   ���#ea0000���#67abd1$��15,19,38,330q�6�   �� 5   
   $��15,73,38,10q�6   ���#7d00d3 �� TabStripPlacement$
 Left=�6A   ���#e03817.@�5      �� $��SELECT��6   $��-2,-2,-31,-38q�6&   ���#160e5c���#ff0000���#38f634$��5q�6�   .��5      �� .��5      � $��	0,0,0,274q�6   $	��653��6.   	 � ColumnDefinitions	 5      �� 5      �� 5      
 � RowDefinitions
 5      �� 5      $
��auto �6,   �� 5      $��* �6,   .+�5      �� $��Enter Media Name :��6$   $��30(�6>   $��10,1,-11,39q�6L   $��1��6a   $��2��6q   �� 5      -   5         ��Name$ 	MediaName��5   "   $��6,6,-7,4q�65   $��1��6G   $��20(�6T   $��1��6b   �� 5      -   5        $ SelectButtonConfirm��5   !   $��CONFIRM��6>   $��1��6P   $��20(�6]   ���#164e0f���#ff0065$��5q�5!   (   
��� ���$��1��5"   $   $��75��5#      $	��130��6   $��204,41,-7,-76q�6)   6@   �� 5$      $��All Media Names :��6$   $��0��6=   $��Center=�6M   $��30(�6j   $	��Top=�6x   �� 5%      -   5        $ 
MediaNames��5%   $   $��0��68   ���#00fff6$��18(�6_   $��23,40,0,-276q�6m   5&      5'      5(      �� 5)      -   5        $
��EDIT��5)      $��-2,28,-31,-65q�6$   ���#160e5c���#ff0000���#38f634$��5q�6�   .��5*      � $��	-62,0,0,0q�6   	 5+      �� 5,      $
��0.5* �6+   �� 5-      .+�5/      �� $��0��6#   $��2��63   $��
93,0,348,0q�6G   .��50      � .+�51      �� $ Center=�6(   $��30(�6?   $	��Top=�6M   $��Seleted Media :��6e   $��42��6|   $��	33,0,33,0q�6�   �� 52      -   5        $ SelectedMediaList��52   (   $��0,47,0,0q�6C   53      54      �� 55      $��Enter Media Name: ��6    $��30(�6:   $��172,0,-48,0q�6H   $��1��6]   �� 56      -   5        $ MediaNameToDelete��56      $��1��69   $
��Left=�6I   $	��Top=�6d   $	��333��6|   $��
154,61,0,0q�6�   $��34��6�   $��20(�6�   �� 57      -	   5        $ DeleteButton��58   v   ���#164e0f���#ff0065
��� ���$��5q�6;   $��Confirm Delete��6O   $��20(�6h   $��1��6�   $��172,112,28,128q�6�   6�   �� 59      -
   5        $ UpdateSelectedMedia��59      ���#164e0f���#ff0065
��� ���$��5q�5:   ;   $��Update List��6O   $��20(�6e   $��1��6s   $��172,205,28,33q�6�   6�   5;      5<      �� 5=      -   5         ��Name$ 
BuyTabItem��5=      $	��BUY��6*   $��-9,65,-31,-109q�67   ���#160e5c���#ff0000���#38f634$��5q�6�   .��5>      � -   5        $��31,0,0,0q�5>      .+�5?      �� $0��*Click On The Screen To Update Your Bill : ��5@      $��10,85,-9,171q�5A      $��58��6+   $��30(�5B      �� 5C      -   5        $
 Bill��5C       $��22,117,-21,134q�5D      $ Center=�5E      $��40(�66   �� 5F      -   5        $ 	BuyButton��5F      $
��BUY!��60   $��20(�6?   ���#164e0f���#ff0065$��5q�5H   (   
��� ���$��75��5J      $��107,193,225,46q�6   65   5L      5M      �� 5N      $��CHANCE��6   $��-2,110,-31,-153q�6&   ���#160e5c���#ff0000���#38f634$��5q�6�   .��5O      � .+�5P      �� -   5        $ ChanseButton��5P      $��TRY YOUR CHANCE !!!��63   $��20(�6Q   ���#164e0f���#ff0065$��5q�5R   (   
��� ���$��75��5T      $��119,111,213,128q�6   66   5U      5V      5X      5Y      5Z      