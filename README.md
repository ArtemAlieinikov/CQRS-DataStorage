## Apache Cassandra Best practices

**Queries**:

* Do not execute "select * from table;" (Because this is a multi partition query where Cassandra needs to fetch the data from almost all the nodes)

* Do not use "allow filtering" option while querying the Cassandra Database.

* Query only on  partition keys rather than on clustering keys when there is a equality filter.
               example : Select * from table where A=? and B =? (Here A and B must be partition keys rather than B as a clustering key).
               
* Do not use IN clause queries to query the data in cassandra.

 

**Schema**:

* Create a partition keys in cassandra table such that each partition key size does not exceed 100 mb. If the partition key size increases beyond 100 mb add another partition key to the table so that it decreases the partition size.

* Try to update the data rather than deleting the data(because deletion in cassandra creates a tombstone and is detrimental in cassandra)

* Try to create a ttl and use time window compaction strategy (cassandra 3.0.9) rather than deleting or updating the data.
And updates and deletes are strongly not recommended in Cassandra.

* Do not create secondary indexes in Cassandra.They will hammer the cluster.

* Do not use user defined functions in Cassandra.

 

**Batch statements**:

Try to batch the statements to the same table and same partition key.

* Do not batch the statements which are of 

    1.) Same table and different partition keys.

    2.) Different tables and different partition keys.

* Not more than 10 mutations(writes) per batch.

* Use prepared statements wherever necessary.

* Usage of pagination is recommended in the code wherever it is necessary.

 

**Tombstones best practices**:

If there is no option to delete or update a row.

* Delete the data for a whole partition key or clustering key rather than deleting  a row. Even if you delete one row or whole partition key Cassandra creates only one tombstone.

* Do not insert null values. Try to insert empty values instead of null values.

---
**Usefull links**

 - Tombstones understanding - http://www.beyondthelines.net/databases/cassandra-tombstones/
