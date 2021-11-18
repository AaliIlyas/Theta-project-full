import React, { useState, useEffect } from "react";
import { OrderApiModel } from "../api/OrderApiModel";
import "./Orders.css"

export function Orders(): JSX.Element {
    const [data, setData] = useState<OrderApiModel[]>([]);
    const [cards, setCards] = useState<JSX.Element[]>([]);
    const [refresh, setRefresh] = useState<boolean>(false);

    useEffect(() => {
        fetch("https://localhost:5001/Order")
            .then(r => r.json())
            .then(data => setData(data))
            .then(() => {
                var cards = createOrderCards(data)
                setCards(cards);
                setRefresh(false);
            })
    }, [refresh])

    const totalCost = data.reduce((a, current) => {
        return a + current.product.price;
    }, 0)

    return (
        <div className="orders-component">
            <h1 className="title">All Orders</h1>
            <p>Total Cost: £{totalCost.toFixed(2).toString()}</p>
            <button onClick={onRefresh}>Refresh</button>
            <br/>
            <div className="cards-container">
                {cards}
            </div>
        </div>
    )

    function createOrderCards(data: OrderApiModel[]) : JSX.Element[] {
        return data.map(o => {
            return (
                <div className="order-cards">
                    <div>Id: {o.orderId}</div>
                    <div>{o.date.toString().split("T")[0]}</div>
                    <div>{o.customer.firstName} {o.customer.lastName}</div>
                    <div>{o.product.name}</div>
                    <div>£{o.product.price.toFixed(2).toString()}</div>
                    <button className="delete-order" onClick={() => deleteOrder(o.orderId)}>Delete</button>
                </div>
            )
        })
    }

    function onRefresh() {
        setRefresh(true);
    }

    function deleteOrder(id : number) : void {
        const url = `https://localhost:5001/Order?id=${id}`
        fetch(url, {
            method: 'DELETE'
        })
        .then(() => setRefresh(true));
    }
}
