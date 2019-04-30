```c#

   IEnumerable<int> idealSizes = from count in cohortStudentCount
                                          where count < 15 && count > 20
                                          orderby count ascending
                                          select count;

```
