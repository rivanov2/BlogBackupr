   M S B A M L   `   `   `  ����F  BHAPExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HAPExplorerHAPExplorer  5          HAPExplorer.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      'hapclr-namespace:HAPExplorer    5      -   5        $��HAPExplorerWindow��5   ?     � Title$  Html Agility Pack Tester��6   $	��578��6&   $	��745��63    � WindowStyle$ ThreeDBorderWindow=�6X   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��366* �6   �� 5	      $
��357* �6    � RowDefinitions 5   
   �� 5      $
��200* �6   �� 5      $��40 �6   �� 5      $
��300* �6   .+�5   
   o� $��Stretch=�6   $��2��6-   $��2��6>   .@�5      m� $
��File��6   .@�5      m� -   5        $��mnuOpenFile��5       m� InputGestureText$ Ctrl+O��6.   $��Open File..��6H   6]   m� 5      -   5        $��
mnuOpenUrl��5      $ Ctrl+L��6-   $��
Open Url..��6G    � ToolTip$ 
Open a Url��6[   6p   �� 5      m� 5      -   5        $��mnuExit��5      $
��Exit��6*   $ Alt+F4��68   6R   5      5      �� 5   
   -   5        $��txtHtml��5   $   $��0,20,0,0q�6   $ �� HorizontalScrollBarVisibility$ Visible=�63   " �� VerticalScrollBarVisibility$ Visible=�6[    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�6�   $��Stretch=�6�   $��2��6�   �� 5   
   
 �� Orientation$
 
Horizontal=�6   $��1��6.   $��2��6<   $��2q�6P   $��Bottom=�6[   .+�5      �� -   5        $��btnParse��5       $��5q�6   .��6G   Parse6N   �� 5      -   5        $��btnTestCode��5       $��5q�6   .��6M   	Test Code6X   �� 5      $��60,5,0,5q�6   $
��Left=�6&   .��6<   Search Tags6I   �� 5      -   5        $��txtSearchTag��5   (   $��0,5,15,5q�6   $	��206��6<   �� 5      -	   5        $��	btnSearch��5       $��5q�6   .��6I   Find6O   �� 5      -
   5        $��chkFromCurrent��5   T   $��5q�6   $��Center=�6"   $��From Current��6=   6T   �� 5       -   5        $��chkXPath��5    M   $��5q�6   $��Center=�6"   $��XPath��6=   6M   5!      �� 5"   
   -   5        $��tabControl1��5"   &   $��0,0,0,0q�6   $��2��69   $��2��6F   .@�5#      �� -   5        $��tabNodeTree��5#   )   $��	Node Tree��6   .��5$      �  5%      �� 5&      $
��366* �6+   �� 5'      $
��357* �6+   .+�5)          HAPExplorer.HtmlNodeViewer  -   5          Name$ HtmlNodeViewer1��5)   )   $��0,0,0,0q�6B   $y�Hidden=�6S   $��0��6g   $��Stretch=�6t   $��1��6�   %   HAPExplorer.HtmlAttributeViewer  5*      -   5          Name$ HtmlAttributeViewer1��5*   .   $��0,0,0,0q�6L   $y�Hidden=�6]   $��Stretch=�6q   $��1��6�   $��0��6�   �� 5+      -   5        $��gridSplitter1��5+   4   $��0,0,0,0q�6#   $��12��6I    � Cursor$ SizeWE��6T    �� ResizeDirection$ Columns=�6d   $��0��6~      HAPExplorer.NodeTreeView  5,      -   5          Name$ hapTree��5,   '      HAPExplorer.NodeTreeView   SelectedItemChanged$! hapTree_SelectedItemChanged��6I   $��0,0,0,0q�68   $��Normal$�6{   $��Stretch=�6�   $��0��6�   5.      5/      �� 50      -   5        $��tabSearchResults��50      $��Search Results��6.   .��51      �� -   5        $��listResults��51      6/   52      53      54      55      