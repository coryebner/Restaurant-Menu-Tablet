   M S B A M L   `   `   `  ����  WpfApplication4    WpfApplication4.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6?   -   5          �Name$  sideMenu��5       � Title$ 
menuOption��5      $	��451��5	      $	��690��6   $��	163,0,0,0q�6    � Left$	 400��6.    � WindowStartupLocation$ Manual=�69    � WindowStyle$
 None=�6X    � AllowsTransparency . 
������ .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   �� ���	#FFF4F4F5$��8,0,1,8q�6%    �� RadiusY$
 29.5��66    �� RadiusX$
 43.5��6E   
���   �6T   �� 5   
   $��24,22,17.733,33q�6   .��5      �� $	��624��6   $��379.951��6&   .+�5      �� -   5        	 ��Name$	 titleOfItemLabel��5      $��
Food Label��62   $��0,0,1.684,0q�6G   $��22(�6\   $
��Bold"�6j   $��Center=�6|   A� 5      $��72��6   .+�5      �� -   5        $	 	costLabel��5      $��
Cost Label��6/   $��18.667(�6D   $	��Top=�6V   $
��Bold"�6n   �� 5      -   5        
 ��Name$
 addToBillButton��5      $��Add to Order��66   $��64,8,0,1.17q�6M   ��5      �� 5       �� EndPoint$	 0,1&�62    �� 
StartPoint$	 0,0&�6A   .��5   "   �  � Color$ 	#FFF3F3F3��6/    � Offset$ 0Q�6A   � 5   "   $ 	#FFEBEBEB��6/   $	 0.5Q�6A   � 5   "   $ 	#FFDDDDDD��6/   $	 0.5Q�6A   � 5   "   $ 	#FFD2D4D3��6/   $ 1Q�6A   5      5      �� 5      $��Quantity : ��6   $��18.667(�62    J� RenderTransformOrigin$ 0.415,0.515&�6D   $
��Left=�6h   $��92.285��6�   A� 5      $��39,1,0,0q�6"   $��Stretch=�64   $��Center=�6R    A� Columns$ 3��6m   $	��100��6y   .+�5      �� -   5        $��lessItem��5   9   $��-��6!   $��25��6-   $��25��6I   6T   �� 5       -   5        $��quantityBox��5    0   $��25��6$   $��1��6C   $��25��6L    �� TextAlignment$ Center=�6W   $��Center=�6n   �� 5!      -   5        $��moreItem��5!   9   $��+��6!   $��25��6-   $��25��6I   6T   5#      5%      �� 5&      -	   5         ��Name$ 	foodImage��5&      $	��157��6+   $��8,0,17.951,0q�68   �� 5'      -
   5         ��Name$ descriptionBox��5'      $
��Wrap=�64   $ ��Item description goes here��6H   $��169.46��6j   $��16(�6z   �� 5(      -   5        $	 AllergyLabel��5(      $��Allergy Warning��6.   $��18.667(�6H   $
��Bold"�6Z   A� 5)      $��80��6   .+�5*      �� -   5        $��Peanut��5*   0   $��
peanut.png��6   $
��Fill=�6>   $
��Left=�6M   $��96.976��6h   $��	0,0,0,-40q�6w   �� 5+      -   5        $��Gluten��5+   0   $��
gluten.png��6   $
��Fill=�6>   $��-93,0,0,-40q�6M   $
��Left=�6b   $��92.974��6}   5,      �� 5-      $��Special Request��6   $��18.667(�62   $
��Bold"�6D   �� 5.      -   5        $��SpecialRequestBox��5.       �� TextWrapping$
 Wrap=�63   $C��=Want your dish made in a special way? Add your comments here.��6G   �� 5/      $��-��6   $
��Left=�6$   $��16.998��6?   $
��Bold"�6N   $��18.667(�6`   ���	#FFDA1010$��-97.691,0,0,0q�6�   $��36��6�   50      51      52      53      