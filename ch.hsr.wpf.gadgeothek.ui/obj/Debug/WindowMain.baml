   M S B A M L   `   `   `  ����S  Och.hsr.wpf.gadgeothek.ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ch.hsr.wpf.gadgeothek.uich.hsr.wpf.gadgeothek.ui  5   	   )    #ch.hsr.wpf.gadgeothek.ui.WindowMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ch.hsr.wpf.gadgeothek.ui     5   	   /domainch.hsr.wpf.gadgeothek.domain     5   	   -   5        $	��800��5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1000��6)    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ MyResources.xaml?�6%   5      %    5      .��5      ]� 
����·�.+�5   
   ]� $	��Top=�6   .+�5      ]� $	��Top=�6   .+�5   
   ��    
TitleStyle#��[  5      $��
Admin-Tool��5      $
��Left=�5      �� 5       -   5        $��NewGadgetBtn��5#        DeleteButtonStyle#��[ 5!      $��Delete Gadget��5$      $��Right=�5%      �� 5'      -   5        $��DeleteGadgetBtn��5)        ButtonStyle#��[ 5(      $��
New Gadget��5+      $��Right=�5,      5-      ]� 5.      $
��10 0q�5/      $��Right=�50      $��Bottom=�51      .+�52      �� -   5        $��	ComboList��55        ComboBoxStyle#��[ 53       �� Text$ Bibliotheken��54      $��Right=�57      ��58      ��  �� Path$ Bibliotheken�59      5:      �� 5<   
   -   5        $
��Tabs��5<   "   $
��Auto��6   .@�5=      �� -   5        $��Gadgets��5=      .��5>      &   System.Windows.Controls.DataGrid  -   5        $��GadgetsData��5@        	GridStyle#��[ 5?      ��5A      �� $ Gadgets�5B      5D      �� 5E      -   5        $��Loans��5E      .��5F        -	   5        $��	LoansData��5H      #��[ 5G      ��5I      �� $ Loans�5J      5K      �� 5L      -
   5        $��Reservations��5L      .��5M        -   5        $��ReservationsData��5O      #��[ 5N      ��5P      �� $ Reservations�5Q      5R      �� 5S      -   5        $��	Customers��5S      .��5T        -   5        $��CustomersData��5V      #��[ 5U      ��5W      �� $ 	Customers�5X      5Y      5Z      5]      5^      