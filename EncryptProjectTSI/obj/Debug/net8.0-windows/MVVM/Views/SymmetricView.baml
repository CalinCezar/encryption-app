   M S B A M L   `   `   `  ����L  HEncryptProjectTSI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EncryptProjectTSI.MVVM.ViewsEncryptProjectTSI.MVVM.Views  5      m;clr-namespace:EncryptProjectTSI.CustomControls.UserControls-EncryptProjectTSI.CustomControls.UserControls  5   	   ?$clr-namespace:EncryptProjectTSI.CoreEncryptProjectTSI.Core  6Y   0    *EncryptProjectTSI.MVVM.Views.SymmetricView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:EncryptProjectTSI.MVVM.Views     5      SuserControl;clr-namespace:EncryptProjectTSI.CustomControls.UserControls     5   	   5core$clr-namespace:EncryptProjectTSI.Core     6Y   .��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      �� 5      $	��140 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$
 Test��5      $	��360��6#   $
��auto��6/   �� 5      -   5        $ Encrypt��5      $��Encrypt��6&   $��16(�68   $
��auto��6F   $��80��6T   6_   �� 5      -   5        $ Decrypt��5      $��Decrypt��6&   $��16(�68   $
��auto��6F   $��80��6T   6_   �� 5      -   5        $ Reverse��5      $��50��6&   $��60��62   .��5      �� $��/images/reverse1.png��6   $��40��67   $��40��6B   5      o� 5      .@�5      m� $��KeySize��6   $
��auto��6,   $��50��69   
�������
���iii�.@�5      m� -   5        $��size128��5   :   $	��128��6   $��16(�6,   6I   m� 5      -   5        $��size196��5   :   $	��196��6   $��16(�6,   6I   m� 5      -   5        $��size256��5   :   $	��256��6   $��16(�6,   6I   5      5      �� 5      -   5        $ GenerateKey��5      $��Generate Key��6*   $
��auto��6A   $
��auto��6O   6\   5       � 5"   
   $��1��6    � ColumnDefinitions 5#      �� 5$      �� 5%      .+�5(      � $��0��6   .+�5)      �� 
�������6   =   7EncryptProjectTSI.CustomControls.UserControls.InputText  5*      -	   5          Name$ Input��5*   (   $
��auto��67   $
��auto��6E      Placeholder$ 
Text Input��6R   5+      � 5-      $��1��6   .+�5.      �� 
�������6     5/      -
   5        $ Output��5/   (   $
��auto��68   $
��auto��6F   $ Text Output��6S   50      52      � 53   
   $��2��6    54      �� 55      �� 56      .+�59      � $��0��6   .+�5:      �� 
���iii�6     5;      -   5        $ 	PublicKey��5;   (   $
��auto��6;   $
��auto��6I   $ 
Public Key��6V   5<      � 5=      $��1��6   .+�5>      �� 
���iii�6     5?      -   5        $ 
PrivateKey��5?   (   $
��auto��6<   $
��auto��6J   $ IV Key��6W   5@      5A      5B      5C      