Ext.application({
    name: 'Fiddle',

    launch: function () {
        Ext.tip.QuickTipManager.init();
        let myStore, myColumns,
            myFields = [];

        myStore = Ext.create('Ext.data.Store', {
            fields: myFields,
            autoLoad: true,
            proxy: {
                url: 'https://localhost:7003/companies',
                type: 'ajax',
                useDefaultXhrHeader: false,
                // headers: {
                //     'Access-Control-Allow-Origin': '*',
                //     'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, DELETE, PUT',
                //     'Access-Control-Allow-Headers': 'x-requested-with, Content-Type, origin, authorization, accept, client-security-token'
                // },
                reader: {
                    type: 'json'
                }
            },
        });
        myColumns = [{
            xtype: 'rownumberer',
            width: 50,
            sortable: false
        }];

        myStore.load({
            scope: this,
            callback: function (records, operation, success) {
                // the operation object
                // contains all of the details of the load operation
                console.log(records);
                let recordsList = records.map(el => el.getData());
                // const distinctProperties = [...new Set(recordsList.flatMap(obj => Object.keys(obj)))];
                const distinctProperties = [...new Set(recordsList.flatMap(obj => Object.keys(obj)).filter(key => key !== 'id'))];
                console.log("distinctProperties", distinctProperties)
                for (const element of distinctProperties) {
                    if (element === 'Company Name') {
                        myColumns.push({
                            text: element,
                            dataIndex: element,
                            width: 100,
                            sorter: multipleSort()
                        });
                    } else {
                        myColumns.push({
                            text: element,
                            dataIndex: element,
                            width: 100,
                        });
                    }
                }
                let myGrid = Ext.create('Ext.grid.Panel', {
                    title: 'Grid with 1000 Columns',
                    scrollable: true,
                    columnLines: true,
                    multiColumnSort: true,
                    store: myStore,
                    selModel: {
                        selType: 'cellmodel'
                    },
                    columns: {
                        items: myColumns
                    },
                    bbar: [{
                        xtype: 'button',
                        width: '20%',
                        docked: 'top',
                        text: 'Export to CSV',
                        handler: function () {
                            recordsList = myStore.getData().items.map(el => el.getData());

                            // Generate the CSV data
                            let csvData = createFile(distinctProperties, recordsList);

                            // Encode the CSV data as a base64-encoded string
                            downloadFile("text/csv", "export.csv", csvData);
                        },
                    },
                    {
                        xtype: 'button',
                        width: '20%',
                        docked: 'top',
                        text: 'Export to XLS',
                        handler: function () {
                            recordsList = myStore.getData().items.map(el => el.getData());

                            // Generate the CSV data
                            let csvData = createFile(distinctProperties, recordsList);

                            // Encode the CSV data as a base64-encoded string
                            downloadFile("application/vnd.ms-excel", "export.xls", csvData);
                        },
                    }
                    ],

                });
                Ext.create('Ext.tab.Panel', {
                    width: '100%',
                    height: 500,
                    renderTo: document.body,
                    items: [myGrid]
                });
            }
        });
    }
});


function multipleSort() {
    return function (a, b) {
        // console.log("model1, model",a, b)
        console.log("this, direction", this, this.getDirection());
        const aYears = a.get('Years in Business'), bYears = b.get('Years in Business'), direction = this.getDirection();
        if (this.getId().split('-')[0] === 'Company Name') {
            if (!Ext.isEmpty(direction) && direction == 'ASC') {

                if (aYears === bYears) {
                    return a.data['Company Name'] > b.data['Company Name'] ? -1 : 1;
                }
                return 0;
            } else {
                if (!Ext.isEmpty(direction) && direction == 'DESC') {
                    if (aYears === bYears) {
                        return a.data['Company Name'] < b.data['Company Name'] ? 1 : -1;
                    }
                    return 0;
                }
            }
        }
    };
}

function createFile(header, records) {
    let csvData = header.join(",") + "\n";

    // Generate the rest of the CSV data
    records.forEach(element => {
        let row = element;
        header.forEach((key, j) => {
            let currentValue = row[key] || "";
            if (currentValue.includes(',')) {
                currentValue = `"${currentValue}"`;
            }
            csvData += currentValue;
            if (j < header.length - 1) {
                csvData += ",";
            }
        });
        csvData += "\n";
    });
    return csvData;
}

function downloadFile(mimeType, fileName, data) {
    // Encode the data as a base64-encoded string
    let base64Data = Ext.util.Base64.encode(data);

    // Create the `data` URI
    let fileUri = "data:" + mimeType + ";base64," + base64Data;

    // Create an `<a>` element and simulate a click on it
    let link = document.createElement("a");
    link.href = fileUri;
    link.download = fileName;
    link.click();
}

