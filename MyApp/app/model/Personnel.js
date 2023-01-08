Ext.define('MyApp.model.Personnel', {
    extend: 'MyApp.model.Base',

    fields: [
        'name', 'email', 'phone'
    ],
   
    sorters: [{
        property: 'companyName',
        direction: 'ASC'
    }],
    proxy: {
        type: 'ajax',
        url: 'getCompanies',
        reader: {
            type: 'json',
            rootProperty: 'data'
        }
    }
});
