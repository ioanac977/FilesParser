/**
 * This view is an example list of people.
 */
Ext.define('MyApp.view.main.List', {
    extend: 'Ext.grid.Panel',
    xtype: 'mainlist',

    requires: [
        'MyApp.store.Personnel'
    ],

    title: 'Personnel',

    store: {
        type: 'personnel'
    },

    columns: [],
    listeners: {
        beforerender: function(a,b){
            this.columns.push({
                text: Ext.String.capitalize("lala"),
                dataIndex: "lala",
                flex: 1,
                sortable: true
            });
           // let fields = me.getStore().getFields();
            // for (const element of fields) {
            //     let field = element;
            //     if (field.name !== 'companyName') {
            //         me.columns.push({
            //             text: Ext.String.capitalize(field.name),
            //             dataIndex: field.name,
            //             flex: 1,
            //             sortable: true
            //         });
            //     }
            // }
        }
    }
   
});
