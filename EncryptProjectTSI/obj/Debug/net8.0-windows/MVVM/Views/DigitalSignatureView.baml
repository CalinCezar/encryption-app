   M S B A M L   `   `   `  ����L  HEncryptProjectTSI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EncryptProjectTSI.MVVM.ViewsEncryptProjectTSI.MVVM.Views  5      m;clr-namespace:EncryptProjectTSI.CustomControls.UserControls-EncryptProjectTSI.CustomControls.UserControls  5   	   7    1EncryptProjectTSI.MVVM.Views.DigitalSignatureView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:EncryptProjectTSI.MVVM.Views     5      SuserControl;clr-namespace:EncryptProjectTSI.CustomControls.UserControls     5   	   .��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      �� 5      $	��140 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$
 Test��5      $	��360��6#   $
��auto��6/   �� 5      -   5        $ Encrypt��5      $
��Sign��6&   $��16(�65   $
��auto��6C   $��80��6Q   6\   �� 5      -   5        $ Decrypt��5      $��Verify��6&   $��16(�67   $
��auto��6E   $��80��6S   6^   �� 5      -   5        $ Reverse��5      $��50��6&   $��60��62   .��5      �� $��/images/reverse1.png��6   $��40��67   $��40��6B   5      o� 5      .@�5      m� $��KeySize��6   $
��auto��6,   $��50��69   
�������
���iii�.@�5      m� -   5        $��size1024��5   ;   $
��1024��6   $��16(�6-   6K   m� 5      -   5        $��size2048��5   ;   $
��2048��6   $��16(�6-   6K   m� 5      -   5        $��size4096��5   ;   $
��4096��6   $��16(�6-   6K   5      5      �� 5      -   5        $ GenerateKey��5      $��Generate Key��6*   $
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
��auto��6J   $ 
Privat Key��6W   5@      5A      5B      5C      