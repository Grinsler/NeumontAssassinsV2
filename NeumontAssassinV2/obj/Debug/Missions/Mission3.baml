   M S B A M L   `   `   `  ����  NeumontAssassinV2)    #NeumontAssassinV2.Missions.Mission3   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��600��5      $	��800��6(   .��5      � -   5          �Name$  MainGrid��5      
���   � � 	Resources 5	   
    �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin	 �� ScaleX
 �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y � RowDefinitions ��Name �� Triggers P� Property P� Value �� 
TargetName��%:  '��       '��     �� 5
      " ��6   .�5      ��  � ��$ 3��64   �� 5       � ��$ 0��60   �� 5       � ��$ 1��6-   �� 5       � ��
 �����6/   �� 5       � ��$ 20(�6-   �� 5       � ��$ 	15,20,0,0q�6,   5      �� 5      " ��6   .�5      ��  � ��
 �����6/   �� 5       � ��
 ���� 6/   �� 5       � ��$ 0��60   �� 5       � ��$ 3��64   �� 5       � ��$ 20(�6-   �� 5       � ��$
 Left=�6?   �� 5       � ��$ 5,5,5,5q�6,   �� 5       � ��$ Normal$�6.   �� 5       � ��$ 30��6+   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ border��6v   $ 5,5,5,5��6%   $��1,1,1,1q�6<   $ 0.5,0.5&�6V   ���	#FFFFFFFFz�5    "   V� 5!   &   .~�5"   *   �� $	 1Q�69   $
 1Q�6D   �� 5#   *   $ 0Q�68   $ 0Q�6C   �� 5$   *   $ 0Q�6:   T� 5%   *   $ 0Q�6=   $ 0Q�6C   5&   '   ._�5(   "   �� $ border1��6j   #��z��6)   $ 5,5,5,5��6S   ._�5)   &   �  5*   *   �� 5+   .   $
��0.5* �6<   �� 5,   .   $
��0.5* �6<   .+�5.   *   �� $ contentPresenter��6�   $��Center=�6;   $��2��6W   $
��Left=�6h   $��5,0,0,0q�6�   5/   '   50   #   51       52      P� 53   "    � {� .  . �54   &   �� $ border1��6@    �@J�Opacity$	 0.5Q�6U   �� 55   &   $ border��6@    �@J�Opacity$ 1Q�6T   �� 56   &   $ contentPresenter��6@    �@J�Opacity$	 0.5Q�6^   57   #   P� 58   "    � �� . . �59   &   �� $ border��6H    � z� 5:   *   V� 5;   .   .~�5<   2   �� $		 0.9Q�6A   $	
 0.9Q�6N   �� 5=   2   $ 0Q�6@   $ 0Q�6K   �� 5>   2   $ 0Q�6B   T� 5?   2   $ 0Q�6E   $ 0Q�6K   5@   /   5B   '   5C   #   5E      5G      5H      5I       � ColumnDefinitions 5J   
   �� 5K      $��1* �6   �� 5L      $��1* �6   �� 5M      $��1* �6    5O   
   �� 5P      $��5* �6   �� 5Q      $��1* �6   �� 5R      $��1* �6   �� 5S      $��1* �6   .+�5V   
   �� -   5         ��Name$ TheBackground��5V      $��3��5W      $��/Images/MainMenuBack.png��5X      $��4��5Y      �� 5Z   
   
�������$��3��5[      $��1��5\      $��3��5]       J� Opacity$	 0.8Q�5^       �� RadiusX$ 10��5_       �� RadiusY$ 10��5`      $��5,5,11,5q�5a      5b      �� 5c   
   -   5         ��Name$ 	testLabel��5c      $	��200��5d      $��CLICK TO PROCEED��5e      $��1��5f      $��4��5g      5h      �� 5i   
   -   5        $ 	testLabe2��5i      $��50��5j      $y�Hidden=�5k      �� 5n   
   -   5         ��Name$
 but1��5n      $��2��5o      $	��Top=�5p      $y�Hidden=�5t      $��	10,5,15,0q�5u      �� 5v   
   -   5        $
 but2��5v      $��2��5w      $��Bottom=�5x      $y�Hidden=�5|      $��	10,0,15,5q�5}      �� 5~   
   -   5        $
 but3��5~      $��3��5      $	��Top=�5�      $y�Hidden=�5�      $��	10,0,15,0q�5�      �� 5�   
   -   5        $
 but4��5�      $��3��5�      $��Bottom=�5�      $y�Hidden=�5�      $��
10,0,15,10q�5�      5�      5�      