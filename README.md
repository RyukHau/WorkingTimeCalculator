# Description

## Overview

The main design of this tool is to calculate the total of working hours. I used holiday data provided by the Taiwan government and the general working time zone to design my tool.

> I designed the working time zone as 0900 am to 1800 pm, and rest time is 1200.
>
> File as CSV
>
> Taiwan government holiday document : [Link](https://data.ntpc.gov.tw/datasets/308DCD75-6434-45BC-A95F-584DA4FED251)

## Logic

I will list the working time zone in advance.

Then I calculate the working hours on the first day. If the intermediate judgment is the same day, I will directly use the total working time zone to calculate.

After completing the first day calculation, I will calculate the working hours between the first day and the end.

Finally, I calculate the working hours on the end day.

Thank for you rading.

---

# 說明

## 概述

該工具主要設計是根據台灣政府提供的假日資料與一般上班工作時區計算出我們在工作區間一共工作了多少工時。

> 工作時區我設計為：上午 0900 至 下午 1800，午休為 1200。
> 
> 檔案為 CSV
> 
> 台灣政府假日文件鏈接：[Link](https://data.ntpc.gov.tw/datasets/308DCD75-6434-45BC-A95F-584DA4FED251)

## 邏輯

我將預先列出上班時區。

然後我先計算出第一天工時，中間判斷如是結束時間為同一天，我將直接使用總計上班時區進的凡是進行計算。

完成第一天計算後，我將計算第一天至結束之間的工時。

最後，我再計算結束日的工時。

以上感謝您的閱讀
