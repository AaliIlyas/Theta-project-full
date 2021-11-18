import React, { useState, useEffect } from "react";
import { CustomerApiModel } from "../api/CustomerApiModel";
import { ProductApiModel } from "../api/ProductApiModel";
import { Navigate } from "react-router-dom";
import "./Shop.css";

export function Shop(): JSX.Element {
    const [data, setData] = useState<ProductApiModel[]>([])
    const [customer, setCustomer] = useState<CustomerApiModel[]>([])

    const [currentCustomer, setCurrentCustomer] = useState<number>(1);
    const [product, setProduct] = useState<number>(1);
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        fetch("https://localhost:5001/Product")
            .then(response => response.json())
            .then(r => setData(r));

        fetch("https://localhost:5001/Customer")
            .then(r => r.json())
            .then(r => setCustomer(r));
    }, [])

    const options = data.map(p => {
        return <option value={p.productId}>{p.name}</option>
    })

    const customers = customer.map(c => {
        return <option value={c.customerId}>{c.firstName} {c.lastName}</option>
    })

    var cards = data.map(p => {
        return (
            <div className="product-card" onClick={() => setProduct(p.productId)}>
                <div>{p.name}</div>
                <div>£{p.price.toFixed(2).toString()}</div>
            </div>
        )
    })

    return (
        <div className="shop-page">
            <div className="shop-headings">
                <h1>Shop</h1>
                <br />
            </div>
            <h3>All Items available</h3>
            <div className="product-card-container">
                {cards}
            </div>

            <h3>Make a purchase</h3>
            <form onSubmit={handleSubmit}>
                <div className="purchase">
                    <div className="input-box">
                        <label>Customer: </label>
                        <select className="input-field" onChange={(e) => { setCurrentCustomer(parseInt(e.target.value)); }} value={currentCustomer}>
                            {customers}
                        </select>
                    </div>

                    <div className="input-box">
                        <label>Item: </label>
                        <select className="input-field" onChange={(e) => { setProduct(parseInt(e.target.value)); }} value={product}>
                            {options}
                        </select>
                    </div>
                </div>

                <button type="submit">Purchase</button>
            </form>
            {success ? <p>Success. Order has been added.</p> : ""}
        </div>
    )

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const req = {
            "Date": new Date(),
            "CustomerId": currentCustomer,
            "ProductId": product
        }

        fetch("https://localhost:5001/Order/", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(req)
        })
            .then(() => <Navigate to="/orders" />)
            .then(() => setSuccess(true))
    }
}
