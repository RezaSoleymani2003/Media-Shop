   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6   
����  �$	��600��5	      $	��400��6,    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �� $��10,10,10,10q�6   
����� �5      � 5   
    � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��Center=�6   
���i��$��
0,72,0,228q�5   %   $��2��69   $��50(�5      $��Kristen ITC)�6   ��5      �� 5      �� 5   $   $�WELCOME!��6(   �� 6:   �� 6F   �� 6L   �� 6X   6_   �� 5      -   5         ��Name$ 
ExitButton��5      $��X��6)   $��378,0,0,277q�65    J� RenderTransformOrigin$ 
14.279,0.5&�5      
��� � �
���  ��5      �� 5      $��SELECT  YOUR  ROLE: ��6   $��46,216,82,17q�64   $��20(�5      $��Kristen ITC)�6   
��� ���64   �� 5       -   5         ��Name$ SellerCheckBox��5       $��SELLER��6/   $��15(�6@   
���<��$��Kristen ITC)�6c   $��46,3,-46,-3q�6}   $��1��6�   6�   �� 5!      -   5        $ StudentCheckBox��5!      $��STUDENT��60   $��15(�6B   
���<��$��Kristen ITC)�6e   $��46,69,-46,-69q�6~   $��1��6�   6�   �� 5"      -   5        $ TeacherCheckBox��5"      $��TEACHER��60   $��15(�6B   
���<��$��Kristen ITC)�6e   $��46,142,-46,-142q�6~   $��1��6�   6�   �� 5#      -   5        $ CustomerCheckBox��5#      $��NORMAL CUSTOMER��61   $��15(�6K   
���<��$��Kristen ITC)�6n   $��46,206,-46,-206q�6�   $��1��6�   6�   5%      5&      5'      